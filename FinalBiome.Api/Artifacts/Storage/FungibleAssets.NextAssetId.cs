///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.FungibleAssetsEntries;
public class NextAssetId : StorageEntry<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId>
{
    /// <summary>
    ///  Storing next asset id<br/>
    /// </summary>
    public NextAssetId(Client client) :
        base(client, "FungibleAssets", "NextAssetId")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

