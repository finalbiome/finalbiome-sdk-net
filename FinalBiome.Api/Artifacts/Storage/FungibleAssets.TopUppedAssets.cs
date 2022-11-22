///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.FungibleAssetsEntries;
public class TopUppedAssets : StorageEntry<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.WeakBoundedVecFungibleAssetId>
{
    /// <summary>
    ///  Storing assets which marked as Top Upped<br/>
    /// </summary>
    public TopUppedAssets(Client client) :
        base(client, "FungibleAssets", "TopUppedAssets")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

