///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.BalancesEntries;
public class Reserves : StorageEntry<FinalBiome.Api.Types.PalletBalances.BoundedVecReserveData>
{
    /// <summary>
    ///  Named reserves on some account balances.<br/>
    /// </summary>
    public Reserves(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "Balances", "Reserves")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

