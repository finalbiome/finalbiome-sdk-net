///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class FungibleAssets
{
    /// <summary>
    ///  Storing assets which marked as Top Upped<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.WeakBoundedVecFungibleAssetId?> TopUppedAssets(IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "TopUppedAssets", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.WeakBoundedVecFungibleAssetId>(address, hash);
    }
}

