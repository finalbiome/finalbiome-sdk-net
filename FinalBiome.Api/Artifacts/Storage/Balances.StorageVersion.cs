///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Balances
{
    /// <summary>
    ///  Storage version of the pallet.<br/>
    /// <para></para>
    ///  This is set to v2.0.0 for new networks.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletBalances.Releases?> StorageVersion(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Balances", "StorageVersion", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletBalances.Releases>(address, hash);
    }
}
