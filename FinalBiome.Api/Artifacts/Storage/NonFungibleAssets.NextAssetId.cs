///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.NonFungibleAssetsEntries;
public class NextAssetId : StorageEntry<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId>
{
    /// <summary>
    ///  Storing the next asset id<br/>
    /// </summary>
    public NextAssetId(Client client) :
        base(client, "NonFungibleAssets", "NextAssetId")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

