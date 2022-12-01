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

    /// <summary>
    /// Event emitted when details of some Nfa class has been changed.
    /// </summary>
    public event EventHandler<NfaClassChangedEventArgs>? NfaClassChanged;
    /// <summary>
    /// Event emitted when details of some Nfa instance has been changed.
    /// </summary>
    public event EventHandler<NfaInstanceChangedEventArgs>? NfaInstanceChanged;


    public NfaClient(Client client)
    {
        this.client = client;
        subscriberCancellationTokenSource = new();
        subscriberToClasses = new(this.client, 5, subscriberCancellationTokenSource.Token);
        subscriberToClasses.StorageChanged += subscriberToClassDetailsHandled;
        subscriberToInstances = new(this.client, 5, subscriberCancellationTokenSource.Token);
        subscriberToInstances.StorageChanged += subscriberToInstanceDetailsHandled;
    }

    public static async Task<NfaClient> Create(Client client)
    {
        NfaClient nfaClient = new(client);

        return await Task.FromResult(nfaClient);
    }

    public void Dispose()
    {
        if (subscriberCancellationTokenSource.Token.CanBeCanceled) subscriberCancellationTokenSource.Cancel();
        subscriberCancellationTokenSource.Dispose();
        subscriberToClasses.Dispose();
        subscriberToInstances.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Get all assets ids owned by user from the network.
    /// </summary>
    /// <returns></returns>
    async IAsyncEnumerable<(NfaClassId classId, NfaInstanceId instanceId)> FetchOwnedAssets()
    {
        /// create the partial storage key of all FAs in the game
        var addr = new StaticStorageAddress("NonFungibleAssets", "Accounts", new());
        var queryKey = addr.ToRootBytes();
        var smKey = new StorageMapKey(this.client.Game.Address, StorageHasher.Blake2_128Concat);
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
                    var assetId = AssetIdFromStorageKey(partialKeyLength, key);
                    yield return assetId;
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
        throw new NotImplementedException();
    }

    void subscriberToClassDetailsHandled(object? o, StorageChangedEventArgs<NfaClassDetails> eventArgs)
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

    void subscriberToInstanceDetailsHandled(object? o, StorageChangedEventArgs<NfaAssetDetails> eventArgs)
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
    /// Convert storage key of Accounts storage in the NonFungibleAssets module to asset ids.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="partialKeyLength"></param>
    /// <param name="storageKey"></param>
    /// <returns></returns>
    static (NfaClassId classId, NfaInstanceId instanceId) AssetIdFromStorageKey(int partialKeyLength, StorageKey storageKey)
    {
        // we know what the last part of key are NonFungibleClassId and NonFungibleAssetId with Blake2_128Concat hashes.
        var bytes = storageKey.ToArray();
        // skip root key
        int pos = partialKeyLength;
        // skip hash of a class id
        pos += 16;
        NonFungibleClassId classId = new();
        classId.Decode(bytes, ref pos);
        // skip hash of a asset id
        pos += 16;
        NonFungibleAssetId instanceId = new();
        instanceId.Decode(bytes, ref pos);

        return (classId, instanceId);
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
