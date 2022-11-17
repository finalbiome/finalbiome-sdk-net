
namespace FinalBiome.Api.Storage;

public partial class FungibleAssets2
{
    public async Task<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetDetails?> Assets(FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "Assets", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetDetails>(address, hash);
    }
}

