///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class UpgradedToTripleRefCount : StorageEntry<FinalBiome.Api.Types.Primitive.Bool>
{
    /// <summary>
    ///  True if we have upgraded so that AccountInfo contains three types of `RefCount`. False<br/>
    ///  (default) if not.<br/>
    /// </summary>
    public UpgradedToTripleRefCount(Client client) :
        base(client, "System", "UpgradedToTripleRefCount")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

