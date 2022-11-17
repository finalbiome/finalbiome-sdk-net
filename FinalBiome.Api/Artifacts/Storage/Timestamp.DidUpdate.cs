///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Timestamp
{
    /// <summary>
    ///  Did the timestamp get updated in this block?<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.Bool?> DidUpdate(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Timestamp", "DidUpdate", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.Bool>(address, hash);
    }
}

