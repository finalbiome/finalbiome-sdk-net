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

    /// <summary>
    /// Subscribe to the changes of
    ///  The current authority set.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.SpConsensusAura.Sr25519.AppSr25519.BoundedVecPublic?> AuthoritiesSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Aura", "Authorities", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.SpConsensusAura.Sr25519.AppSr25519.BoundedVecPublic>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

