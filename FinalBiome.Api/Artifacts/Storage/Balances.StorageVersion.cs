///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.BalancesEntries;
public class StorageVersion : StorageEntry<FinalBiome.Api.Types.PalletBalances.Releases>
{
    /// <summary>
    ///  Storage version of the pallet.<br/>
    /// <para></para>
    ///  This is set to v2.0.0 for new networks.<br/>
    /// </summary>
    public StorageVersion(Client client) :
        base(client, "Balances", "StorageVersion")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

