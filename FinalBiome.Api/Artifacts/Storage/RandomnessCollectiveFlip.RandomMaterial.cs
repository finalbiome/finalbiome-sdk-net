///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class RandomnessCollectiveFlip
{
    /// <summary>
    ///  Series of block headers from the last 81 blocks that acts as random seed material. This<br/>
    ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of<br/>
    ///  the oldest hash.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PrimitiveTypes.BoundedVecH256?> RandomMaterial(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("RandomnessCollectiveFlip", "RandomMaterial", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PrimitiveTypes.BoundedVecH256>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Series of block headers from the last 81 blocks that acts as random seed material. This<br/>
    ///  is arranged as a ring buffer with `block_number % 81` being the index into the `Vec` of<br/>
    ///  the oldest hash.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PrimitiveTypes.BoundedVecH256?> RandomMaterialSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("RandomnessCollectiveFlip", "RandomMaterial", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PrimitiveTypes.BoundedVecH256>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

