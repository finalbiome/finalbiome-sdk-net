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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
