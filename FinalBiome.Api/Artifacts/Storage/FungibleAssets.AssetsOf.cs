///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class FungibleAssets
{
    /// <summary>
    ///  Asset ids by owners (organizations).<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Tuple_Empty?> AssetsOf(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "AssetsOf", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Tuple_Empty>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Asset ids by owners (organizations).<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Tuple_Empty?> AssetsOfSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "AssetsOf", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Tuple_Empty>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

