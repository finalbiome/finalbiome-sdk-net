///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Balances
{
    /// <summary>
    ///  Named reserves on some account balances.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletBalances.BoundedVecReserveData?> Reserves(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("Balances", "Reserves", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletBalances.BoundedVecReserveData>(address, hash);
    }
}

