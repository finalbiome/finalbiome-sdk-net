///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.AuraEntries;
public class CurrentSlot : StorageEntry<FinalBiome.Api.Types.SpConsensusSlots.Slot>
{
    /// <summary>
    ///  The current slot of this block.<br/>
    /// <para></para>
    ///  This will be set in `on_initialize`.<br/>
    /// </summary>
    public CurrentSlot(Client client) :
        base(client, "Aura", "CurrentSlot")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

