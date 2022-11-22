///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class NonFungibleAssets
{
    /// <summary>
    ///  Attributes of an assets.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletSupport.AttributeValue?> Attributes(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(nonFungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(boundedVecU8, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "Attributes", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletSupport.AttributeValue>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Attributes of an assets.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletSupport.AttributeValue?> AttributesSubscribe(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(nonFungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(boundedVecU8, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "Attributes", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletSupport.AttributeValue>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

