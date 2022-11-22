///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.NonFungibleAssetsEntries;
public class ClassAttributes : StorageEntry<FinalBiome.Api.Types.PalletSupport.AttributeValue>
{
    /// <summary>
    ///  Attributes of an asset class.<br/>
    /// </summary>
    public ClassAttributes(Client client, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.BoundedVecU8 boundedVecU8) :
        base(client, "NonFungibleAssets", "ClassAttributes")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(boundedVecU8, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

