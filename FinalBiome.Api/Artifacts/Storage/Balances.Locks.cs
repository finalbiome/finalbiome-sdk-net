///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Balances
{
    /// <summary>
    ///  Any liquidity locks on some account balances.<br/>
    ///  NOTE: Should only be accessed when setting, changing and freeing a lock.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletBalances.WeakBoundedVecBalanceLock?> Locks(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("Balances", "Locks", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletBalances.WeakBoundedVecBalanceLock>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Any liquidity locks on some account balances.<br/>
    ///  NOTE: Should only be accessed when setting, changing and freeing a lock.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletBalances.WeakBoundedVecBalanceLock?> LocksSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("Balances", "Locks", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletBalances.WeakBoundedVecBalanceLock>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

