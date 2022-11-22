///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  The current weight for the block.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.FrameSupport.Weights.PerDispatchClass?> BlockWeight(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "BlockWeight", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.FrameSupport.Weights.PerDispatchClass>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The current weight for the block.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.FrameSupport.Weights.PerDispatchClass?> BlockWeightSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "BlockWeight", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.FrameSupport.Weights.PerDispatchClass>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

