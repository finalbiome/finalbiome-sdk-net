///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Grandpa
{
    /// <summary>
    ///  Pending change: (signaled at, scheduled change).<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletGrandpa.StoredPendingChange?> PendingChange(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "PendingChange", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletGrandpa.StoredPendingChange>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Pending change: (signaled at, scheduled change).<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletGrandpa.StoredPendingChange?> PendingChangeSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "PendingChange", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletGrandpa.StoredPendingChange>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

