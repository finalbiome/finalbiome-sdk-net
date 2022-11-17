///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
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
    public async Task<FinalBiome.Api.Types.VecTuple_U32_U32?> EventTopics(FinalBiome.Api.Types.PrimitiveTypes.H256 h256, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(h256, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("System", "EventTopics", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.VecTuple_U32_U32>(address, hash);
    }
}

