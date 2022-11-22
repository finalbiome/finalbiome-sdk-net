///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class FungibleAssets
{
    /// <summary>
    ///  Details of an asset.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetDetails?> Assets(FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "Assets", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetDetails>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  Details of an asset.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetDetails?> AssetsSubscribe(FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "Assets", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetDetails>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

