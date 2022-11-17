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
}

