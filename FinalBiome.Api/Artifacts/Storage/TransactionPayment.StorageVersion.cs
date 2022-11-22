///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.TransactionPaymentEntries;
public class StorageVersion : StorageEntry<FinalBiome.Api.Types.PalletTransactionPayment.Releases>
{
    public StorageVersion(Client client) :
        base(client, "TransactionPayment", "StorageVersion")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

