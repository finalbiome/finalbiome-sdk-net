///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class EventTopics : StorageEntry<FinalBiome.Api.Types.VecTuple_U32_U32>
{
    /// <summary>
    ///  Mapping between a topic (represented by T::Hash) and a vector of indexes<br/>
    ///  of events in the `&lt;Events&lt;T&gt;&gt;` list.<br/>
    /// <para></para>
    ///  All topic vectors have deterministic storage locations depending on the topic. This<br/>
    ///  allows light-clients to leverage the changes trie storage tracking mechanism and<br/>
    ///  in case of changes fetch the list of events of interest.<br/>
    /// <para></para>
    ///  The value has the type `(T::BlockNumber, EventIndex)` because if we used only just<br/>
    ///  the `EventIndex` then in case if the topic has the same contents on the next block<br/>
    ///  no notification will be triggered thus the event might be lost.<br/>
    /// </summary>
    public EventTopics(Client client, FinalBiome.Api.Types.PrimitiveTypes.H256 h256) :
        base(client, "System", "EventTopics")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(h256, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

