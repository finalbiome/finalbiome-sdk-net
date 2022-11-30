using FinalBiome.Api.Extensions;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId;

namespace FinalBiome.Sdk.Test;

public class SubscribeAggregatorTests
{
    [Test]
    /// <summary>
    /// For this test Fa with id = 1 must be top upped
    /// </summary>
    /// <returns></returns>
    public async Task SubscriberTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var client = await Client.Create(config);
        
        using CancellationTokenSource cts = new();
        using SubscribeAggregator<Api.Types.PalletFungibleAssets.Types.AssetAccount> s = new(client, 2, cts.Token);

        /// subscribe to one real address and check events

        // Dave's Fa balance with id = 1
        FungibleAssetId id = new();
        id.Init(1);
        StorageAddress saDaveFa1 = new Api.Storage.FungibleAssetsEntries.Accounts(client.api,
                                                                                  AccountKeyring.Dave(),
                                                                                  id).Address;

        Assert.That(saDaveFa1.ToBytes().ToHex().ToLower(), Is.EqualTo("0xa3b3f3c9f10b799e5c0f367f30a546678ee7418a6531173d60d1f6a82d8f4d51e5e802737cce3a54b0bc9e3d3e6be26e306721211d5404bd9da88e0204360a1a9ab8b87c66c1bc2fcdd37f3c2222cc20d82c12285b5d4551f88e8f6e7eb52b8101000000"));

        StorageChangedEventArgs<Api.Types.PalletFungibleAssets.Types.AssetAccount>? ev = null;
        s.StorageChanged += (o, e) => ev = e;

        await s.Subscribe(saDaveFa1);

        Thread.Sleep(3_000);
        Assert.That(ev?.Key, Is.EqualTo(saDaveFa1.ToBytes()));
        
        s.Unsubscribe(saDaveFa1);
        ev = null;
        Thread.Sleep(2_000);
        Assert.That(ev, Is.Null);
    }

    [Test]
    public async Task SubscriberCancelTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var client = await Client.Create(config);

        using CancellationTokenSource cts = new();
        using SubscribeAggregator<Api.Types.PalletFungibleAssets.Types.AssetAccount> s = new(client, 2, cts.Token);

        /// subscribe to one real address and check events

        // Dave's Fa balance with id = 1
        FungibleAssetId id = new();
        id.Init(1);
        StorageAddress saDaveFa1 = new Api.Storage.FungibleAssetsEntries.Accounts(client.api,
                                                                                  AccountKeyring.Dave(),
                                                                                  id).Address;

        Assert.That(saDaveFa1.ToBytes().ToHex().ToLower(), Is.EqualTo("0xa3b3f3c9f10b799e5c0f367f30a546678ee7418a6531173d60d1f6a82d8f4d51e5e802737cce3a54b0bc9e3d3e6be26e306721211d5404bd9da88e0204360a1a9ab8b87c66c1bc2fcdd37f3c2222cc20d82c12285b5d4551f88e8f6e7eb52b8101000000"));

        StorageChangedEventArgs<Api.Types.PalletFungibleAssets.Types.AssetAccount>? ev = null;
        s.StorageChanged += (o, e) => ev = e;

        await s.Subscribe(saDaveFa1);

        Thread.Sleep(5_000);
        Assert.That(ev?.Key, Is.EqualTo(saDaveFa1.ToBytes()));
        
        cts.Cancel();
        ev = null;
        Thread.Sleep(5_000);
        Assert.That(ev, Is.Null);
    }

    [Test]
    public async Task ReSubscribeTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var client = await Client.Create(config);

        using CancellationTokenSource cts = new();
        using SubscribeAggregator<Api.Types.PalletFungibleAssets.Types.AssetAccount> s = new(client, 2, cts.Token);

        /// subscribe to several addresses

        // Dave's Fa balance with id = 1
        FungibleAssetId id = new();
        id.Init(0);
        StorageAddress saDaveFa1 = new Api.Storage.FungibleAssetsEntries.Accounts(client.api,
                                                                                  AccountKeyring.Dave(),
                                                                                  id).Address;
        FungibleAssetId id2 = new();
        id2.Init(1);
        StorageAddress saDaveFa2 = new Api.Storage.FungibleAssetsEntries.Accounts(client.api,
                                                                                  AccountKeyring.Dave(),
                                                                                  id2).Address;
        FungibleAssetId id3 = new();
        id3.Init(2);
        StorageAddress saDaveFa3 = new Api.Storage.FungibleAssetsEntries.Accounts(client.api,
                                                                                  AccountKeyring.Dave(),
                                                                                  id3).Address;


        StorageChangedEventArgs<Api.Types.PalletFungibleAssets.Types.AssetAccount>? ev = null;
        s.StorageChanged += (o, e) => ev = e;

        await s.Subscribe(saDaveFa1);

        Thread.Sleep(3_000);
        Assert.That(ev?.Key, Is.EqualTo(saDaveFa1.ToBytes()));

        await s.Subscribe(saDaveFa2);
        Thread.Sleep(3_000);

        await s.Subscribe(saDaveFa3);

        ev = null;
        Thread.Sleep(5_000);
        Assert.That(ev, Is.Null);
    }
}
