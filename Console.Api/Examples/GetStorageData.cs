using FinalBiome.Api;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace ConsoleApi.Examples;

using FinalBiome.Api.Extensions;
using FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId;

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
        FinalBiome.Api.Types.SpCore.Crypto.AccountId32 accountId32 = (FinalBiome.Api.Types.SpCore.Crypto.AccountId32)AccountKeyring.Dave().ToAddress().Value2;
        FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId fungibleAssetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
        fungibleAssetId.Init(1);

        var value = await api.Storage.FungibleAssets.Accounts(accountId32, fungibleAssetId).Fetch();

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
        var accountId32 = (FinalBiome.Api.Types.SpCore.Crypto.AccountId32)AccountKeyring.Dave().ToAddress().Value2;
        var fungibleAssetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
        fungibleAssetId.Init(1);

        var sub = api.Storage.FungibleAssets.Accounts(accountId32, fungibleAssetId).Subscribe(cancellationToken);

        //var sub = api.Storage.FungibleAssets.AccountsSubscribe(accountId32, fungibleAssetId, cancellationToken);
        await foreach (var item in sub)
        {
            Console.WriteLine($"Dave has: {item?.Balance.ToHuman()} of FA {fungibleAssetId.ToHuman()}");
        }
    }

    /// <summary>
    /// This example shows how to retrive keys by iterating over map. Here, we manually append one lookup
    /// key to the root and just iterate over the values underneath that.
    /// 
    /// After that we extract last value from key. This needed if we need values of last value from the keys.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task GetKeysAndParseThem(CancellationToken? cancellationToken = null)
    {
        cancellationToken ??= CancellationToken.None;

        Client api = await Client.New();
        var accountId32 = (FinalBiome.Api.Types.SpCore.Crypto.AccountId32)AccountKeyring.Eve().ToAddress().Value2;

        // Cerate a stogre address with empty entry keys for obtaining the root bytes key of the storage
        var addr = new StaticStorageAddress("FungibleAssets", "AssetsOf", new());
        // Obtain the root bytes
        var queryKey = addr.ToRootBytes();
        // We know that the first key is a AccountId32 (the `OrganizationId`) and it hashed by Blake2_128Concat.
        // We can build a `StorageMapKey` that replicates that, and append those bytes to the above.
        var smKey = new StorageMapKey(accountId32, FinalBiome.Api.Storage.StorageHasher.Blake2_128Concat);
        smKey.ToBytes(ref queryKey);

        // Next, we make loop by all keys with page of 10 and agregate it in `allKeys`.
        // Of course, an iterator is preferable in production.
        List<List<byte>> allKeys = new();
        List<byte>? startKey = null;
        List<List<byte>>? keys;
        do
        {
            keys = await api.Storage.FetchKeys(queryKey, 10, startKey, null);

            if (keys is not null && keys.Count != 0)
            {
                startKey = keys.Last();
                allKeys.AddRange(keys);
            }
            if (((CancellationToken)cancellationToken).IsCancellationRequested) keys = null;
        } while (keys is not null && keys.Count != 0);

        Console.WriteLine("Obtained keys:");

        foreach (var key in allKeys)
        {
            Console.WriteLine($"Key: {key.ToHex()}");
        }

        // now we can decode the last value of the key
        foreach (var key in allKeys)
        {
            // we know what the last part of key is FungibleAssetId with Blake2_128Concat hash.
            // So, cut the root key and 16 bytes more: 16 - it's bytes of hash Blake2_128Concat.
            // Note: we can use this approach when the store uses concatenating hashers or Identity hasher.
            var assetIdEncoded = key.ToArray()[(queryKey.Count + 16) ..]; // TODO: remove hadr code by auto generaging FromBytes static methods for all storages.
            Console.WriteLine($"Hex: {assetIdEncoded.ToHex()}");

            var assetId = new FungibleAssetId();
            // assetId.Init(assetIdEncoded);

            assetId.Decode(assetIdEncoded);

            Console.WriteLine($"Key: {assetId.ToHuman()}");
        }
    }
}
