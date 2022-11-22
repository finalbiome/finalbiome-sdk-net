///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class NonFungibleAssets
{
    /// <summary>
    ///  The assets held by any given account.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Tuple_Empty?> Accounts(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(nonFungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "Accounts", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Tuple_Empty>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The assets held by any given account.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Tuple_Empty?> AccountsSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId nonFungibleAssetId, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(nonFungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "Accounts", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Tuple_Empty>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

