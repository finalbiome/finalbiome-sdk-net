///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.NonFungibleAssetsEntries;
public class Classes : StorageEntry<FinalBiome.Api.Types.PalletSupport.TypesNfa.ClassDetails>
{
    /// <summary>
    ///  Details of asset classes.<br/>
    /// </summary>
    public Classes(Client client, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId) :
        base(client, "NonFungibleAssets", "Classes")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

