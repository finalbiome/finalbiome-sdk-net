///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class TransactionPayment
{
    public async Task<FinalBiome.Api.Types.PalletTransactionPayment.Releases?> StorageVersion(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("TransactionPayment", "StorageVersion", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletTransactionPayment.Releases>(address, hash);
    }

    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletTransactionPayment.Releases?> StorageVersionSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("TransactionPayment", "StorageVersion", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletTransactionPayment.Releases>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

