///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class LastRuntimeUpgrade : StorageEntry<FinalBiome.Api.Types.FrameSystem.LastRuntimeUpgradeInfo>
{
    /// <summary>
    ///  Stores the `spec_version` and `spec_name` of when the last runtime upgrade happened.<br/>
    /// </summary>
    public LastRuntimeUpgrade(Client client) :
        base(client, "System", "LastRuntimeUpgrade")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
