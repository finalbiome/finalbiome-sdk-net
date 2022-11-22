///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.TimestampEntries;
public class Now : StorageEntry<FinalBiome.Api.Types.Primitive.U64>
{
    /// <summary>
    ///  Current time for the current block.<br/>
    /// </summary>
    public Now(Client client) :
        base(client, "Timestamp", "Now")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

