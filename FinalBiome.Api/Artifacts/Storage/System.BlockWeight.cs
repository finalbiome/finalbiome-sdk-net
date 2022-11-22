///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.SystemEntries;
public class BlockWeight : StorageEntry<FinalBiome.Api.Types.FrameSupport.Weights.PerDispatchClass>
{
    /// <summary>
    ///  The current weight for the block.<br/>
    /// </summary>
    public BlockWeight(Client client) :
        base(client, "System", "BlockWeight")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

