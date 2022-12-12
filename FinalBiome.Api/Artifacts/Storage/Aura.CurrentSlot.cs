///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
