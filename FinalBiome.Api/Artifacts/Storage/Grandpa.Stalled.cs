///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Grandpa
{
    /// <summary>
    ///  `true` if we are currently stalled.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Tuple_U32_U32?> Stalled(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "Stalled", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Tuple_U32_U32>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  `true` if we are currently stalled.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Tuple_U32_U32?> StalledSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "Stalled", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Tuple_U32_U32>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

