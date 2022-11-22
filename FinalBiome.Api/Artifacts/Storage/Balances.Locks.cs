///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.BalancesEntries;
public class Locks : StorageEntry<FinalBiome.Api.Types.PalletBalances.WeakBoundedVecBalanceLock>
{
    /// <summary>
    ///  Any liquidity locks on some account balances.<br/>
    ///  NOTE: Should only be accessed when setting, changing and freeing a lock.<br/>
    /// </summary>
    public Locks(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "Balances", "Locks")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

