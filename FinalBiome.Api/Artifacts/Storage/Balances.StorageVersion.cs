///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
