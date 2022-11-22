///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  Hash of the previous block.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PrimitiveTypes.H256?> ParentHash(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "ParentHash", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PrimitiveTypes.H256>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Hash of the previous block.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PrimitiveTypes.H256?> ParentHashSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "ParentHash", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PrimitiveTypes.H256>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

