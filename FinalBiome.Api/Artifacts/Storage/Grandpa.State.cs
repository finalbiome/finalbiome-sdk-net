///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Grandpa
{
    /// <summary>
    ///  State of the current authority set.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletGrandpa.StoredState?> State(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "State", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletGrandpa.StoredState>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  State of the current authority set.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletGrandpa.StoredState?> StateSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Grandpa", "State", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletGrandpa.StoredState>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

