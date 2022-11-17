///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  True if we have upgraded so that AccountInfo contains three types of `RefCount`. False<br/>
    ///  (default) if not.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.Bool?> UpgradedToTripleRefCount(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "UpgradedToTripleRefCount", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.Bool>(address, hash);
    }
}

