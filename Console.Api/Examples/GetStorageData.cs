using FinalBiome.Api;
using FinalBiome.Api.Storage;

namespace ConsoleApi.Examples;

public static class GetStorageData
{
    /// <summary>
    /// This is the highest level approach to using this API.
    /// We use auto generated storage class to retrive the storage data.
    /// </summary>
    /// <returns></returns>
    public static async Task SimpleGet()
    {
        Client api = await Client.New();
        //FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32 = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
        FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32 = (FinalBiome.Api.Types.SpCore.Crypto.AccountId32)AccountKeyring.Dave().ToAddress().Value2;
        FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
        fungibleAssetId.Init(1);

        var value = await api.Storage.FungibleAssets.Accounts(accountId32, fungibleAssetId);

        Console.WriteLine($"Account {accountId32.ToHuman()} has {value?.Balance.ToHuman()} of FA with id {fungibleAssetId.ToHuman()}");
    }

    /// <summary>
    /// This example shows the highest level approach to subscribing to the storage changes.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task GetAndWatch(CancellationToken? cancellationToken = null)
    {
        Client api = await Client.New();
        FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32 = (FinalBiome.Api.Types.SpCore.Crypto.AccountId32)AccountKeyring.Dave().ToAddress().Value2;
        FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
        fungibleAssetId.Init(1);

        List<StorageMapKey> storageEntryKeys = new List<StorageMapKey>();
        storageEntryKeys.Add(new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));
        storageEntryKeys.Add(new StorageMapKey(fungibleAssetId, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat));

        StaticStorageAddress address = new StaticStorageAddress("FungibleAssets", "Accounts", storageEntryKeys);

        var sub = api.Storage.SubscribeStorage<FinalBiome.Api.Types.PalletFungibleAssets.Types.AssetAccount>(address, cancellationToken);
        await foreach (var item in sub)
        {
            Console.WriteLine($"Dave has: {item?.Balance.ToHuman()} of FA {fungibleAssetId.ToHuman()}");
        }
    }
}

