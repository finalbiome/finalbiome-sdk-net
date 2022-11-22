///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  The number of events in the `Events&lt;T&gt;` list.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U32?> EventCount(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "EventCount", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U32>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The number of events in the `Events&lt;T&gt;` list.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U32?> EventCountSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "EventCount", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U32>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

