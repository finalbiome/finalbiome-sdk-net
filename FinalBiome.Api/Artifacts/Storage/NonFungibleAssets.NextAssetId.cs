///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
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


#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
