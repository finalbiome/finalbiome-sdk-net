///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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

