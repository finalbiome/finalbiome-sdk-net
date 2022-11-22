///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  Total length (in bytes) for all extrinsics put together, for the current block.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U32?> AllExtrinsicsLen(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "AllExtrinsicsLen", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U32>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Total length (in bytes) for all extrinsics put together, for the current block.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U32?> AllExtrinsicsLenSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "AllExtrinsicsLen", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U32>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

