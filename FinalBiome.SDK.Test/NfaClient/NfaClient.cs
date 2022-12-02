using FinalBiome.Api.Extensions;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Types.PalletSupport;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId;

namespace FinalBiome.Sdk.Test;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
public class NfaClientTests
{
    [Test]
    public async Task GetClassDetailsTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var classId = 1u;
        var details = await client.GetClassDetails(classId);
        Assert.That(details, Is.Not.Null);
        Assert.That(details.Name.ToHuman(), Is.EqualTo("\"Stave\""));
    }

    [Test]
    public async Task GetClassDetailsNotFoundTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var classId = 9999u;
        Assert.ThrowsAsync<NfaClassNotFoundException>(() => client.GetClassDetails(classId));
    }

    [Test]
    /// <summary>
    /// For this test Dave must owned instance 0 of nfa 1
    /// </summary>
    /// <returns></returns>
    public async Task GetInstanceDetailsTest()
    {
        // by new nfa
        (NfaClassId classId, NfaInstanceId instanceId) = await NetworkHelpers.ExecBuyNfaMechanic();
        
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var details = await client.GetInstanceDetails(classId, instanceId);
        Assert.Multiple(() =>
        {
            Assert.That(details, Is.Not.Null);
            Assert.That(details.Owner.ToHuman(), Is.EqualTo("\"5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy\""));
            Assert.That(details.Locked.Value, Is.EqualTo(InnerLocker.None));
        });
    }

    [Test]
    public async Task GetInstanceDetailsNotFoundTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var classId = 9999u;
        var instanceId = 9999u;
        Assert.ThrowsAsync<NfaInstanceNotFoundException>(() => client.GetInstanceDetails(classId, instanceId));
    }
    
    [Test]
    public async Task ClassSubscriptionTest()
    {
        // for test events about changes of nfs classes, we create a test attribute and listen changes on the nfa class.
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        Client cl = await Client.Create(config);
        NfaClient client = new(cl);

        var classId = 1u;
        int eventEmittedCount = 0;
        client.NfaClassChanged += (o, e) =>
        {
            eventEmittedCount++;
            if (eventEmittedCount != 2) return;
            Assert.Multiple(() =>
            {
                Assert.That(e.classId, Is.EqualTo(classId));
                Assert.That(e.details, Is.Not.Null);
            });
            Assert.That(e.details?.Attributes.Value, Is.EqualTo(10));
        };

        // get details. it subscribe the sdk to changes.
        var details = await client.GetClassDetails(classId);
        Thread.Sleep(2_000);
        Assert.Multiple(() =>
        {
            Assert.That(details?.Attributes.Value, Is.EqualTo(9));
            Assert.That(eventEmittedCount, Is.EqualTo(1));
        });


        // create attr. it should emit event from subscription
        await NetworkHelpers.CreateClassAttribute(classId, "testAttr", "testVal");

        Assert.That(eventEmittedCount, Is.EqualTo(2));

        //cleanup
        await NetworkHelpers.RemoveClassAttribute(1, "testAttr");
        Assert.That(eventEmittedCount, Is.EqualTo(3));
    }

    // [Test] // TODO: finish test after the ability to delete assets
    public async Task InstanceRemovedEventTest()
    {
        // by new nfa
        // (NfaClassId classId, NfaInstanceId instanceId) = await NetworkHelpers.ExecBuyNfaMechanic();
        
        // string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        // ClientConfig config = new(eveGame);
        // Client cl = await Client.Create(config);
        // NfaClient client = new(cl);

        // var details = await client.GetInstanceDetails(classId, instanceId);
        // Thread.Sleep(2_000);
        
        // int eventEmittedCount = 0;
        // client.NfaInstanceChanged += (o, e) =>
        // {
        //     eventEmittedCount++;
        //     // if (eventEmittedCount != 1) return;
        //     Assert.Multiple(() =>
        //     {
        //         Assert.That(e.classId, Is.EqualTo(classId));
        //         Assert.That(e.details, Is.Null);
        //     });
        // };
        // Assert.That(eventEmittedCount, Is.EqualTo(1));
    }


}
