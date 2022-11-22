///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.NonFungibleAssetsEntries;
public class NextClassId : StorageEntry<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId>
{
    /// <summary>
    ///  Storing the next class id<br/>
    /// </summary>
    public NextClassId(Client client) :
        base(client, "NonFungibleAssets", "NextClassId")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

