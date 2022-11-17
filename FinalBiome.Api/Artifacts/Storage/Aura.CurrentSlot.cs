///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Aura
{
    /// <summary>
    ///  The current slot of this block.<br/>
    /// <para></para>
    ///  This will be set in `on_initialize`.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.SpConsensusSlots.Slot?> CurrentSlot(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Aura", "CurrentSlot", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.SpConsensusSlots.Slot>(address, hash);
    }
}

