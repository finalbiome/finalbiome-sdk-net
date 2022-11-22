///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class FungibleAssets
{
    /// <summary>
    ///  The holdings of a specific account for a specific asset<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetAccount?> Accounts(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "Accounts", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetAccount>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The holdings of a specific account for a specific asset<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetAccount?> AccountsSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "Accounts", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetAccount>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

