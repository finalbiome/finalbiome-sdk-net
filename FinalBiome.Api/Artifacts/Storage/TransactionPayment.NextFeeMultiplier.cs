///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class TransactionPayment
{
    public async Task<FinalBiome.Api.Types.SpArithmetic.FixedPoint.FixedU128?> NextFeeMultiplier(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("TransactionPayment", "NextFeeMultiplier", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.SpArithmetic.FixedPoint.FixedU128>(address, hash);
    }

    public async IAsyncEnumerable<FinalBiome.Api.Types.SpArithmetic.FixedPoint.FixedU128?> NextFeeMultiplierSubscribe(CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("TransactionPayment", "NextFeeMultiplier", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.SpArithmetic.FixedPoint.FixedU128>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

