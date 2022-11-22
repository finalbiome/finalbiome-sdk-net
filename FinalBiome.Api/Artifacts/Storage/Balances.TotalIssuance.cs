///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class Balances
{
    /// <summary>
    ///  The total units issued in the system.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Primitive.U128?> TotalIssuance(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Balances", "TotalIssuance", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Primitive.U128>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The total units issued in the system.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Primitive.U128?> TotalIssuanceSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("Balances", "TotalIssuance", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Primitive.U128>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

