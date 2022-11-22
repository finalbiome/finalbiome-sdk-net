///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using FinalBiome.Api.Storage;
namespace FinalBiome.Api.Storage.FungibleAssetsEntries;
public class TopUpQueue : StorageEntry<FinalBiome.Api.Types.Tuple_Empty>
{
    /// <summary>
    ///  Accounts with assets which maybe need to top upped in next block.<br/>
    /// </summary>
    public TopUpQueue(Client client, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32) :
        base(client, "FungibleAssets", "TopUpQueue")
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        this.Address = new StaticStorageAddress(palletName, entryName, storageEntryKeys);
    }

}

