///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class NonFungibleAssets
{
    /// <summary>
    ///  Attributes of an asset class.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletSupport.AttributeValue?> ClassAttributes(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(boundedVecU8, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "ClassAttributes", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletSupport.AttributeValue>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Attributes of an asset class.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletSupport.AttributeValue?> ClassAttributesSubscribe(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(boundedVecU8, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "ClassAttributes", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletSupport.AttributeValue>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

