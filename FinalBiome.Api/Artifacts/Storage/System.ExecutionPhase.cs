///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class System
{
    /// <summary>
    ///  The execution phase of the block.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.FrameSystem.Phase?> ExecutionPhase(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("System", "ExecutionPhase", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.FrameSystem.Phase>(address, hash);
    }
}
