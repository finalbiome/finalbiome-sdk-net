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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
