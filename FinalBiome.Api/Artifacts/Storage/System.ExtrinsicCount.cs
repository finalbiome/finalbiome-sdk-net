///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class ExtrinsicCount : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    /// <summary>
    ///  Total extrinsics count for the current block.<br/>
    /// </summary>
    public ExtrinsicCount(Client client) :
        base(client, "System", "ExtrinsicCount")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

