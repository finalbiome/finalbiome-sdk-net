///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class ExecutionPhase : StorageEntry<FinalBiome.Api.Types.FrameSystem.Phase>
{
    /// <summary>
    ///  The execution phase of the block.<br/>
    /// </summary>
    public ExecutionPhase(Client client) :
        base(client, "System", "ExecutionPhase")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

