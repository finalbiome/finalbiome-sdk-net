///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class AllExtrinsicsLen : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    /// <summary>
    ///  Total length (in bytes) for all extrinsics put together, for the current block.<br/>
    /// </summary>
    public AllExtrinsicsLen(Client client) :
        base(client, "System", "AllExtrinsicsLen")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

