///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Timestamp
{
    /// <summary>
    ///  Current time for the current block.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U64?> Now(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Timestamp", "Now", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U64>(address, hash);
    }
}

