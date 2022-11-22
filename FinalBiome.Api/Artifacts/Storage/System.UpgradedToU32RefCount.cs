///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class UpgradedToU32RefCount : StorageEntry<FinalBiome.Api.Types.Primitive.Bool>
{
    /// <summary>
    ///  True if we have upgraded so that `type RefCount` is `u32`. False (default) if not.<br/>
    /// </summary>
    public UpgradedToU32RefCount(Client client) :
        base(client, "System", "UpgradedToU32RefCount")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

