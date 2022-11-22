///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.TransactionPaymentEntries;
public class NextFeeMultiplier : StorageEntry<FinalBiome.Api.Types.SpArithmetic.FixedPoint.FixedU128>
{
    public NextFeeMultiplier(Client client) :
        base(client, "TransactionPayment", "NextFeeMultiplier")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

