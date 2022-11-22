///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.TimestampEntries;
public class DidUpdate : StorageEntry<FinalBiome.Api.Types.Primitive.Bool>
{
    /// <summary>
    ///  Did the timestamp get updated in this block?<br/>
    /// </summary>
    public DidUpdate(Client client) :
        base(client, "Timestamp", "DidUpdate")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

