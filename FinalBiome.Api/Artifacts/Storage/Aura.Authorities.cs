///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.AuraEntries;
public class Authorities : StorageEntry<FinalBiome.Api.Types.SpConsensusAura.Sr25519.AppSr25519.BoundedVecPublic>
{
    /// <summary>
    ///  The current authority set.<br/>
    /// </summary>
    public Authorities(Client client) :
        base(client, "Aura", "Authorities")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

