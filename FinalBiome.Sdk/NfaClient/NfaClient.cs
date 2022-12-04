using System.Collections.Concurrent;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Types.PalletSupport;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId;

namespace FinalBiome.Sdk;

using StorageKey = List<byte>;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using NfaAssetDetails = Api.Types.PalletSupport.TypesNfa.AssetDetails;
using NfaClassDetails = Api.Types.PalletSupport.TypesNfa.ClassDetails;
/// <summary>
/// Client for access to fungible assets on network for the given game.<br/>
/// This client contains all information about Nfa - classes, instances and their attributes.<br/>
/// If the status of any Nfa is changed, this client will update information about it and trigger the appropriate events.
/// </summary>
/// 
/// For performance reasons, the clietn doesn't hold information about all existing in the game assets.
/// It fetches information only about NFAs which holds by user.
/// When any changes with assets are happends, NfaClient notified about it.<br/>
/// After client initialization, it fetches all nfa id, owned by games, all asset ids, owned by user and
/// starts listening the network events about any changes with nfa assets
/// (note: someday we will need to refactor this via custom rpc subscription).
/// 
/// The gameplay includes not only the creation and deletion of assets, but also the manipulation 
/// of their attributes.
/// And these manipulations will eventually be the most frequent operation on the network.
/// Therefore, we need to keep subscriptions to change each attribute of each asset we own.
/// (note: will need to re-engineer this with our own rpc subscription someday).
public class NfaClient : IDisposable
{
    readonly Client client;

    /// <summary>
    /// All Nfa classes ids of the current game.
    /// </summary>
    readonly List<NfaClassId> gameClasses;

    /// <summary>
    /// Cancellation token for all subscriber tasks
    /// </summary>
    /// <returns></returns>
    readonly CancellationTokenSource subscriberCancellationTokenSource;

    /// <summary>
    /// Collection of all users owned Nfa assets and details about them.<br/>
    /// Value is null if data wasn't fetched from the network.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="instanceId)>"></param>
    /// <returns></returns>
    readonly ConcurrentDictionary<(NfaClassId classId, NfaInstanceId instanceId), NfaAssetDetails> nfaInstances = new();

    /// <summary>
    /// Collection of classes of all users owned Nfa assets and details about them.<br/>
    /// Value doesn't exist,the data wasn't fetched from the network.
    /// </summary>
    /// <param name="classId"></param>
    /// <returns></returns>
    readonly ConcurrentDictionary<NfaClassId, NfaClassDetails> nfaClasses = new();

    /// <summary>
    /// Subscriber to classes details
    /// </summary>
    readonly SubscribeAggregator<NfaClassDetails> subscriberToClasses;

    /// <summary>
    /// Subscriber to instances details
    /// </summary>
    readonly SubscribeAggregator<NfaAssetDetails> subscriberToInstances;

    readonly NetworkEventsListener networkEventsListener;

    /// <summary>
    /// Event emitted when details of some Nfa class has been changed.
    /// </summary>
    public event EventHandler<NfaClassChangedEventArgs>? NfaClassChanged;

    /// <summary>
    /// Event emitted when details of some Nfa instance has been changed.
    /// </summary>
    public event EventHandler<NfaInstanceChangedEventArgs>? NfaInstanceChanged;

    internal NfaClient(Client client, List<NfaClassId> gameClasses)
    {
        this.client = client;
        this.gameClasses = gameClasses;
        subscriberCancellationTokenSource = new();

        subscriberToClasses = new(this.client, 5, subscriberCancellationTokenSource.Token);
        subscriberToClasses.StorageChanged += SubscriberToClassDetailsHander;
        subscriberToInstances = new(this.client, 5, subscriberCancellationTokenSource.Token);
        subscriberToInstances.StorageChanged += SubscriberToInstanceDetailsHandler;

        networkEventsListener = new(this.client);
        networkEventsListener.NfaIssued += NfaIssuedEventHandler;

        client.Auth.StateChanged += HandleUserStateChangedEvent;
    }

    public static async Task<NfaClient> Create(Client client)
    {
        // fetch all game classes and save
        List<NfaClassId> gameClasses = new();
        await foreach (NfaClassId classId in FetchGameNfaClasses(client))
        {
            gameClasses.Add(classId);
        }

        NfaClient nfaClient = new(client, gameClasses);

        return nfaClient;
    }

    public void Dispose()
    {
        if (subscriberCancellationTokenSource.Token.CanBeCanceled) subscriberCancellationTokenSource.Cancel();
        subscriberCancellationTokenSource.Dispose();
        subscriberToClasses.Dispose();
        subscriberToInstances.Dispose();
        networkEventsListener.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Get from the network all classes ids of the current game.
    /// </summary>
    /// <returns></returns>
    static async IAsyncEnumerable<NfaClassId> FetchGameNfaClasses(Client client)
    {
        // create the partial storage key of all Nfa classes of this game
        var addr = new StaticStorageAddress("NonFungibleAssets", "ClassAccounts", new());
        var queryKey = addr.ToRootBytes();
        var smKey = new StorageMapKey(client.Game.Address, StorageHasher.Blake2_128Concat);
        smKey.ToBytes(ref queryKey);

        var partialKeyLength = queryKey.Count;
        
        StorageKey? startKey = null;
        List<StorageKey>? keys;
        do
        {
            keys = await client.api.Storage.FetchKeys(queryKey, 10, startKey, null);

            if (keys is not null && keys.Count != 0)
            {
                startKey = keys.Last();
                foreach (var key in keys)
                {
                    var classId = ClassIdFromStorageKeyOfClasseAccounts(partialKeyLength, key);
                    yield return classId;
                }
            }
        } while (keys is not null && keys.Count != 0);
    }

    /// <summary>
    /// Get from the network all assets ids owned by the user and related to this game.
    /// </summary>
    /// <returns></returns>
    async IAsyncEnumerable<(NfaClassId classId, NfaInstanceId instanceId)> FetchOwnedAssets()
    {
        if (this.client.Auth.UserAddress is null) throw new Exception("User not set");
        // create the partial storage key of all Nfa instances owned by user
        var addr = new StaticStorageAddress("NonFungibleAssets", "Accounts", new());
        var queryKey = addr.ToRootBytes();
        var smKey = new StorageMapKey(this.client.Auth.UserAddress, StorageHasher.Blake2_128Concat);
        smKey.ToBytes(ref queryKey);
        
        var partialKeyLength = queryKey.Count;

        StorageKey? startKey = null;
        List<StorageKey>? keys;
        do
        {
            keys = await this.client.api.Storage.FetchKeys(queryKey, 10, startKey, null);

            if (keys is not null && keys.Count != 0)
            {
                startKey = keys.Last();
                foreach (var key in keys)
                {
                    var assetId = AssetIdFromStorageKeyOfAccounts(partialKeyLength, key);
                    if (gameClasses.Contains(assetId.classId)) yield return assetId;
                }
            }
        } while (keys is not null && keys.Count != 0);
    }

    /// <summary>
    /// Returns instance details
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="instanceId"></param>
    /// <returns></returns>
    public async Task<NfaAssetDetails> GetInstanceDetails(NfaClassId classId, NfaInstanceId instanceId)
    {
        if (!gameClasses.Contains(classId)) throw new NfaInstanceNotFoundException(classId, instanceId);
        // try get from cache
        if (nfaInstances.TryGetValue((classId, instanceId), out var cachedDetails))
        {
            return cachedDetails;
        }
        // fetch from the network. The best option would be not to request the current value separately, but to return it from the subscription. But it is not clear how to implement this normally.
        NonFungibleClassId nonFungibleClassId = new();
        nonFungibleClassId.Init(value: classId);
        NonFungibleAssetId nonFungibleAssetId = new();
        nonFungibleAssetId.Init(instanceId);
        var detailsEntity = client.api.Storage.NonFungibleAssets.Assets(nonFungibleClassId, nonFungibleAssetId);
        var details = await detailsEntity.Fetch();
        // throw an exception if not exists
        if (details is null) throw new NfaInstanceNotFoundException(classId, instanceId);
        // storing in the cache
        nfaInstances.TryAdd((classId, instanceId), details);
        // subscribe to changes
        await subscriberToClasses.Subscribe(detailsEntity.Address);
        return details;
    }

    /// <summary>
    /// Returns the class details.
    /// </summary>
    /// When retrieves a class details from the network (next time it will returns from the local cache),
    /// in the same time we subscribe to changes of that class in the network.
    /// <param name="classId"></param>
    /// <returns></returns>
    public async Task<NfaClassDetails> GetClassDetails(NfaClassId classId)
    {
        if (!gameClasses.Contains(classId)) throw new NfaClassNotFoundException(classId);

        // try get from cache
        if (nfaClasses.TryGetValue(classId, out var cachedDetails))
        {
            return cachedDetails;
        }

        // fetch from the network. The best option would be not to request the current value separately, but to return it from the subscription. But it is not clear how to implement this normally.
        NonFungibleClassId nonFungibleClassId = new();
        nonFungibleClassId.Init(classId);
        var detailsEntity = client.api.Storage.NonFungibleAssets.Classes(nonFungibleClassId);
        var details = await detailsEntity.Fetch();
        // throw an exception if not exists
        if (details is null) throw new NfaClassNotFoundException(classId);
        // storing in the cache
        nfaClasses.TryAdd(classId, details);
        // subscribe to changes
        await subscriberToClasses.Subscribe(detailsEntity.Address);
        return details;
    }

    /// <summary>
    /// Get attribute value of the class by attribute name
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="attributeName"></param>
    /// <returns></returns>
    public async Task<AttributeValue> GetClassAttribute(NfaClassId classId, string attributeName)
    {
        if (!gameClasses.Contains(classId)) throw new NfaClassNotFoundException(classId);
    
        await Task.Yield();
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get attribute value of the instance by attribute name
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="instanceId"></param>
    /// <param name="attributeName"></param>
    /// <returns></returns>
    public async Task<AttributeValue> GetInstanceAttribute(NfaClassId classId, NfaInstanceId instanceId, string attributeName)
    {
        if (!gameClasses.Contains(classId)) throw new NfaInstanceNotFoundException(classId, instanceId);

        await Task.Yield();
        throw new NotImplementedException();
    }

    void SubscriberToClassDetailsHander(object? o, StorageChangedEventArgs<NfaClassDetails> eventArgs)
    {
        // parse key into nfa class id
        // TODO: cache the size of the root key
        var addr = new StaticStorageAddress("NonFungibleAssets", "Classes", new());
        var initialPos = addr.ToRootBytes().Count;
        byte[]? bytes = eventArgs.Key.ToArray();
        // skip root key
        int pos = initialPos;
        // skip hash of a class id
        pos += 16;
        NonFungibleClassId classId = new();
        classId.Decode(bytes, ref pos);
        
        if (eventArgs.Value is not null)
        {
            nfaClasses.TryAdd(classId, eventArgs.Value);
        }
        else
        {
            // class was destroyed
            nfaClasses.TryRemove(classId, out var _);
            // TODO: need to cleanup all instances. but it is unreal case (removing of class from the network).
        }
        // emit event
        OnNfaClassChangedEvent(new NfaClassChangedEventArgs(classId, eventArgs.Value));
    }

    void SubscriberToInstanceDetailsHandler(object? o, StorageChangedEventArgs<NfaAssetDetails> eventArgs)
    {
        // parse key into nfa class id
        // TODO: cache the size of the root key
        var addr = new StaticStorageAddress("NonFungibleAssets", "Assets", new());
        var initialPos = addr.ToRootBytes().Count;
        byte[]? bytes = eventArgs.Key.ToArray();
        // skip root key
        int pos = initialPos;
        // skip hash of a class id
        pos += 16;
        NonFungibleClassId classId = new();
        classId.Decode(bytes, ref pos);
        // skip hash of an asset id
        pos += 16;
        NonFungibleAssetId instanceId = new();
        instanceId.Decode(bytes, ref pos);
        
        if (eventArgs.Value is not null)
        {
            nfaInstances.TryAdd((classId, instanceId), eventArgs.Value);
        }
        else
        {
            // instance was destroyed
            nfaInstances.TryRemove((classId, instanceId), out var _);
            // TODO: need to cleanup the attributes cache
        }
        // emit event
        OnNfaInstanceChangedEvent(new NfaInstanceChangedEventArgs(classId, instanceId, eventArgs.Value));
    }

    /// <summary>
    /// Handler of network events about new issued assets.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="instanceId"></param>
    async Task NfaIssuedEventHandler(NfaClassId classId, NfaInstanceId instanceId)
    {
        // ignore issuing an asset from another game
        if (!gameClasses.Contains(classId)) return;
        // if user has been owned a new asset, we should subscribe on it changes.
        NonFungibleClassId nonFungibleClassId = new();
        nonFungibleClassId.Init(classId);
        NonFungibleAssetId nonFungibleAssetId = new();
        nonFungibleAssetId.Init(instanceId);
        var detailsEntity = client.api.Storage.NonFungibleAssets.Assets(nonFungibleClassId, nonFungibleAssetId);

        await subscriberToInstances.Subscribe(detailsEntity.Address);
    }

    /// <summary>
    /// Handler to changes of the user state for subscribing to assets owned by user.
    /// </summary>
    /// <param name="isLogged"></param>
    /// <returns></returns>
    async Task HandleUserStateChangedEvent(bool isLogged)
    {
        if (isLogged) {
            // subscribe to all owned assets
            List<StorageAddress> ownedAssetsAdresses = new();
            await foreach ((uint classId, uint instanceId) in FetchOwnedAssets())
            {
                NonFungibleClassId nonFungibleClassId = new();
                nonFungibleClassId.Init(classId);
                NonFungibleAssetId nonFungibleAssetId = new();
                nonFungibleAssetId.Init(instanceId);
                var assetAddress = client.api.Storage.NonFungibleAssets.Assets(nonFungibleClassId, nonFungibleAssetId).Address;
                ownedAssetsAdresses.Add(assetAddress);
            }
            await this.subscriberToInstances.Subscribe(ownedAssetsAdresses);
            // TODO: sub to attributes
        }
        else
        {
            // unsubscribe from assets details changes
            List<StorageAddress> ownedAssetsAdresses = new();
            foreach ((uint classId, uint instanceId) in nfaInstances.Keys)
            {
                NonFungibleClassId nonFungibleClassId = new();
                nonFungibleClassId.Init(classId);
                NonFungibleAssetId nonFungibleAssetId = new();
                nonFungibleAssetId.Init(instanceId);
                var assetAddress = client.api.Storage.NonFungibleAssets.Assets(nonFungibleClassId, nonFungibleAssetId).Address;
                ownedAssetsAdresses.Add(assetAddress);
            }
            nfaInstances.Clear();
            subscriberToInstances.Unsubscribe(ownedAssetsAdresses);
            // unsubscribe from classes details changes
            List<StorageAddress> ownedClassAdresses = new();
            foreach (uint classId in nfaClasses.Keys)
            {
                NonFungibleClassId nonFungibleClassId = new();
                nonFungibleClassId.Init(classId);
                var classAddress = client.api.Storage.NonFungibleAssets.Classes(nonFungibleClassId).Address;
                ownedClassAdresses.Add(classAddress);
            }
            nfaClasses.Clear();
            subscriberToClasses.Unsubscribe(ownedClassAdresses);
            // TODO: unsub from attributes
        }
    }

    /// <summary>
    /// Convert storage key of Accounts storage in the NonFungibleAssets module to asset ids.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="partialKeyLength"></param>
    /// <param name="storageKey"></param>
    /// <returns></returns>
    static (NfaClassId classId, NfaInstanceId instanceId) AssetIdFromStorageKeyOfAccounts(int partialKeyLength, StorageKey storageKey)
    {
        // we know what the last part of key are NonFungibleClassId and NonFungibleAssetId with Blake2_128Concat hashes.
        var bytes = storageKey.ToArray();
        // skip root key
        int pos = partialKeyLength;
        // skip hash of a class id (Blake2_128Concat)
        pos += 16;
        NonFungibleClassId classId = new();
        classId.Decode(bytes, ref pos);
        // skip hash of a asset id (Blake2_128Concat)
        pos += 16;
        NonFungibleAssetId instanceId = new();
        instanceId.Decode(bytes, ref pos);

        return (classId, instanceId);
    }

    /// <summary>
    /// Convert a storage key of ClassAccounts storage in the NonFungibleAssets module to the class id.
    /// </summary>
    /// <param name="partialKeyLength"></param>
    /// <param name="storageKey"></param>
    /// <returns></returns>
    static NfaClassId ClassIdFromStorageKeyOfClasseAccounts(int partialKeyLength, StorageKey storageKey)
    {
        // we know what the last part of key is NonFungibleClassId with Blake2_128Concat hash.
        var bytes = storageKey.ToArray();
        // skip root key
        int pos = partialKeyLength;
        // skip hash of a class id (Blake2_128Concat)
        pos += 16;
        NonFungibleClassId classId = new();
        classId.Decode(bytes, ref pos);
        return classId;
    }

    void OnNfaClassChangedEvent(NfaClassChangedEventArgs e)
    {
        NfaClassChanged?.Invoke(this, e);
    }

    void OnNfaInstanceChangedEvent(NfaInstanceChangedEventArgs e)
    {
        NfaInstanceChanged?.Invoke(this, e);
    }


}
