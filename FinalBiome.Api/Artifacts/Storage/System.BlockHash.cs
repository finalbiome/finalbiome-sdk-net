///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  Map of block numbers to block hashes.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PrimitiveTypes.H256?> BlockHash(FinalBiome.Api.Types.Primitive.U32 u32, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        StaticStorageAddress address = new StaticStorageAddress("System", "BlockHash", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PrimitiveTypes.H256>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Map of block numbers to block hashes.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PrimitiveTypes.H256?> BlockHashSubscribe(FinalBiome.Api.Types.Primitive.U32 u32, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(u32, FinalBiome.Api.Storage.StorageHasher.Twox64Concat));

        StaticStorageAddress address = new StaticStorageAddress("System", "BlockHash", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PrimitiveTypes.H256>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

