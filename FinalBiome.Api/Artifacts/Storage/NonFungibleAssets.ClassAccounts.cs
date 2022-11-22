///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Storage;
public partial class NonFungibleAssets
{
    /// <summary>
    ///  The classes owned by any given account.<br/>
    /// </summary>
    public async Task<FinalBiome.Api.Types.Tuple_Empty?> ClassAccounts(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, IEnumerable<byte>? hash = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "ClassAccounts", storageEntryKeys);

        return await client.Storage.Fetch<FinalBiome.Api.Types.Tuple_Empty>(address, hash);
    }

    /// <summary>
    /// Subscribe to the changes of
    ///  The classes owned by any given account.<br/>
    /// </summary>
    public async IAsyncEnumerable<FinalBiome.Api.Types.Tuple_Empty?> ClassAccountsSubscribe(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId nonFungibleClassId, CancellationToken? cancellationToken = null)
    {
        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(nonFungibleClassId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("NonFungibleAssets", "ClassAccounts", storageEntryKeys);

        var sub = client.Storage.SubscribeStorage<FinalBiome.Api.Types.Tuple_Empty>(address, cancellationToken);
        await foreach (var item in sub)
        {
            yield return item;
        }
    }
}

