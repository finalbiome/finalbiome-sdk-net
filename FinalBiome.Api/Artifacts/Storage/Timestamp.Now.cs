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

    /// <summary>
    /// Subscribe to the changes of
    ///  Current time for the current block.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U64?> NowSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Timestamp", "Now", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U64>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

