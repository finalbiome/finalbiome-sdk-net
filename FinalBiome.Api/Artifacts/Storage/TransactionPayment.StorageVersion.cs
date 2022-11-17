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
}

