///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class EventCount : StorageEntry<FinalBiome.Api.Types.Primitive.U32>
{
    /// <summary>
    ///  The number of events in the `Events&lt;T&gt;` list.<br/>
    /// </summary>
    public EventCount(Client client) :
        base(client, "System", "EventCount")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

