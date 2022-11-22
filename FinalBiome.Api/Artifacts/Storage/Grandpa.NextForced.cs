///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Grandpa
{
    /// <summary>
    ///  next block number where we can force a change.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U32?> NextForced(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "NextForced", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U32>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  next block number where we can force a change.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U32?> NextForcedSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "NextForced", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U32>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

