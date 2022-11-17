///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Aura
{
    /// <summary>
    ///  The current authority set.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.SpConsensusAura.Sr25519.AppSr25519.BoundedVecPublic?> Authorities(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Aura", "Authorities", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.SpConsensusAura.Sr25519.AppSr25519.BoundedVecPublic>(address, hash);
    }
}

