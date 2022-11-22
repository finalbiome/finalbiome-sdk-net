///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.NonFungibleAssetsEntries;
public class Attributes : StorageEntry<FinalBiome.Api.Types.PalletSupport.AttributeValue>
{
    /// <summary>
    ///  Attributes of an assets.<br/>
    /// </summary>
    public Attributes(Client client, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8) :
        base(client, "NonFungibleAssets", "Attributes")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(nonFungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(boundedVecU8, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

