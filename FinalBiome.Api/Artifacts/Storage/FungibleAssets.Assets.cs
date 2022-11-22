///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.FungibleAssetsEntries;
public class Assets : StorageEntry<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetDetails>
{
    /// <summary>
    ///  Details of an asset.<br/>
    /// </summary>
    public Assets(Client client, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId) :
        base(client, "FungibleAssets", "Assets")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

