///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.FungibleAssetsEntries;
public class AssetsOf : StorageEntry<FinalBiome.Api.Types.Tuple_Empty>
{
    /// <summary>
    ///  Asset ids by owners (organizations).<br/>
    /// </summary>
    public AssetsOf(Client client, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId) :
        base(client, "FungibleAssets", "AssetsOf")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

