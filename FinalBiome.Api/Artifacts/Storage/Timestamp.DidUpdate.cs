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

    /// <summary>
    /// Subscribe to the changes of
    ///  Did the timestamp get updated in this block?<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.Bool?> DidUpdateSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Timestamp", "DidUpdate", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.Bool>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

