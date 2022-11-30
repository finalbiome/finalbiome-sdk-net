using System.Collections.Concurrent;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId;

namespace FinalBiome.Sdk;

using StorageKey = List<byte>;
using FaAssetId = UInt32;
using FaAssetBalance = UInt128;

/// <summary>
/// Client for access to fungible assets on network for the given game.
/// </summary>
public class FaClient : IDisposable
{
    readonly Client client;

    StorageKey? _storageKeyFAs;
    /// <summary>
    /// Partial storage key of all FAs in the game from AssetsOf storage for parsing subscription notifications.
    /// </summary>
    /// <value></value>
    StorageKey StorageKeyFAs { 
        get {
                if (_storageKeyFAs is null)
                {
                    /// create the partial storage key of all FAs in the game
                    // Cerate a stogre address with empty entry keys for obtaining the root bytes key of the storage
                    var addr = new StaticStorageAddress("FungibleAssets", "AssetsOf", new());
                    var queryKey = addr.ToRootBytes();
                    // We know that the first key is a AccountId32 (the `OrganizationId`) and it hashed by Blake2_128Concat.
                    // We can build a `StorageMapKey` that replicates that, and append those bytes to the above.
                    var smKey = new StorageMapKey(this.client.Game.Address, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat);
                    smKey.ToBytes(ref queryKey);
                    _storageKeyFAs = queryKey;
                }
                return _storageKeyFAs;
            }
    }

    /// <summary>
    /// Holds a balances of all fungible assets of the user.<br/>
    /// * Key - asset Id<br/>
    /// * Value - balance<br/>
    /// If some Fa id doesn't exist, this means that the balance of this asset is 0.
    /// </summary>
    /// <returns></returns>
    public ConcurrentDictionary<FaAssetId, FaAssetBalance> Balances { get; internal set; } = new();

    /// <summary>
    /// Task which listen a subscription on FA changes and updates asset states.
    /// </summary>
    Task? subscriberTask;
    /// <summary>
    /// Cancellation token for subscriberTask
    /// </summary>
    /// <returns></returns>
    CancellationTokenSource subscriberCancellationTokenSource = new();

    /// <summary>
    /// Event emitted when balance of some asset has been changed.
    /// </summary>
    public event EventHandler<FaBalanceChangedEventArgs>? FaBalanceChanged;
    public FaClient(Client client)
    {
        this.client = client;
    }

    /// <summary>
    /// Create instanse of the FA Client
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    public static async Task<FaClient> Create(Client client)
    {
        FaClient faClient = new(client: client);

        return await Task.FromResult(faClient);
    }

    /// <summary>
    /// Fetch from the network all existing FA Ids for the next subscription to them changes
    /// </summary>
    /// <returns></returns>
    async Task<List<FaAssetId>> FetchAllExistingFaIds()
    {
        List<StorageKey> faStorageKeys = new();
        StorageKey? startKey = null;
        List<StorageKey>? keys;
        do
        {
            keys = await client.api.Storage.FetchKeys(StorageKeyFAs, 10, startKey, null);

            if (keys is not null && keys.Count != 0)
            {
                startKey = keys.Last();
                faStorageKeys.AddRange(keys);
            }
        } while (keys is not null && keys.Count != 0);

        return faStorageKeys.Select(AssetIdFromStorageKey).ToList();
    }

    /// <summary>
    /// Subscribe to change on all existed in the game funginble assets. <br/>
    /// We know about all existed FA and we cant subscribe to all of them.
    /// When the balance of the user of any of them is changed, the client will know about it.
    /// </summary>
    /// <returns></returns>
    async Task SubscriberToFaState(List<StorageKey> storageKeys, CancellationToken cancellationToken)
    {
        // create subscription for all FA storage keys
        var sub = await client.api.Rpc.SubscribeStorage(storageKeys, cancellationToken);
        try
        {
            await foreach (var changeSet in sub.data(cancellationToken))
            {
                foreach (var change in changeSet.Changes)
                {
                    var key = change.StorageKey;
                    var valueEncoded = change.StorageValue;

                    // get asset id
                    var assetId = AssetIdFromStorageKey(key);
                    // decode value
                    Api.Types.PalletFungibleAssets.Types.AssetAccount asset = new();
                    asset.Init(valueEncoded);
                    FaAssetBalance balance = (FaAssetBalance)asset.Balance.Value;
                    // save data
                    Balances.TryAdd(assetId, balance);
                    // emit the event
                    OnFaBalanceChangedEvent(new FaBalanceChangedEventArgs(assetId, balance));
                }
            }
        }
        catch (OperationCanceledException)
        {
        //
        }
        // unsubscribe from subscription on the network
        await client.api.Rpc.Unsubscribe(sub);
        // clean stored balances
        Balances.Clear();
    }

    /// <summary>
    /// Create subscriber task to watch on FA balance changes.<br/>
    /// If task already exists, restart them.
    /// </summary>
    /// <returns></returns>
    public async Task StartSubscriber()
    {
        if (client.Auth.UserAddress is null) throw new Exception("User not set");
        if (subscriberCancellationTokenSource.Token.IsCancellationRequested) return;
        await StopSubscriber();

        /// create new task
        // get fa ids
        List<FaAssetId> faIds = await FetchAllExistingFaIds();
        // create storage keys
        List<StorageKey> keys = faIds.Select(id => {
            FungibleAssetId fid = new();
            fid.Init(id);
            return client.api.Storage.FungibleAssets.Accounts(client.Auth.UserAddress, fid).Address.ToBytes();
        }).ToList();
        CancellationToken token = subscriberCancellationTokenSource.Token;
        subscriberTask = Task.Run(async () => await SubscriberToFaState(keys, token), token);
    }

    /// <summary>
    /// Stop subscription if exists.
    /// </summary>
    /// <returns></returns>
    public async Task StopSubscriber()
    {
        if (subscriberCancellationTokenSource.Token.IsCancellationRequested) return;
        if (subscriberTask is not null) 
        {
            // cancel previous subscriber task
            subscriberCancellationTokenSource.Cancel();
            try
            {
                await subscriberTask.WaitAsync(TimeSpan.FromSeconds(10));
            }
            catch (OperationCanceledException)
            {}
            finally
            {
                subscriberCancellationTokenSource.Dispose();
                // create new token source
                subscriberCancellationTokenSource = new();
            }
        }
        Balances.Clear();
    }

    /// <summary>
    /// Decodes a storage key to FA id.
    /// </summary>
    /// <param name="storageKey"></param>
    /// <returns></returns>
    FaAssetId AssetIdFromStorageKey(StorageKey storageKey)
    {
        // we know what the last part of key is FungibleAssetId with Blake2_128Concat hash.
        // So, cut the root key and 16 bytes more: 16 - it's bytes of hash Blake2_128Concat.
        // Note: we can use this approach when the store uses concatenating hashers or Identity hasher.
        var lengthOfHash = 16; // TODO: remove hadr code by auto generaging FromBytes static methods for all storages in th API.
        var assetIdEncoded = storageKey.ToArray()[(StorageKeyFAs.Count + lengthOfHash)..];

        var assetId = new FungibleAssetId();
        assetId.Decode(assetIdEncoded);
        return assetId;
    }

    void OnFaBalanceChangedEvent(FaBalanceChangedEventArgs e)
    {
        FaBalanceChanged?.Invoke(this, e);
    }

    public void Dispose()
    {
        if (subscriberCancellationTokenSource.Token.CanBeCanceled) subscriberCancellationTokenSource.Cancel();
        subscriberCancellationTokenSource?.Dispose();
        GC.SuppressFinalize(this);
    }
}
