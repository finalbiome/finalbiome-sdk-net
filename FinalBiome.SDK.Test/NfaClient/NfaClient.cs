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
        using Client client = await Client.Create(config);

        var classId = 1u;
        var details = await client.Nfa.GetClassDetails(classId);
        Assert.That(details, Is.Not.Null);
        Assert.That(details.Name.ToHuman(), Is.EqualTo("\"Stave\""));
    }

    [Test]
    public async Task GetClassDetailsNotFoundTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        var classId = 9999u;
        Assert.ThrowsAsync<NfaClassNotFoundException>(() => client.Nfa.GetClassDetails(classId));
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
        using Client client = await Client.Create(config);

        var details = await client.Nfa.GetInstanceDetails(classId, instanceId);
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
        using Client client = await Client.Create(config);

        var classId = 0u;
        var instanceId = 9999u;
        Assert.ThrowsAsync<NfaInstanceNotFoundException>(() => client.Nfa.GetInstanceDetails(classId, instanceId));
    }
    
    [Test]
    public async Task ClassSubscriptionTest()
    {
        // for test events about changes of nfs classes, we create a test attribute and listen changes on the nfa class.
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        var classId = 1u;
        int eventEmittedCount = 0;
        client.Nfa.NfaClassChanged += (o, e) =>
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
        var details = await client.Nfa.GetClassDetails(classId);
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

    [Test]
    public async Task NewAssetsSubscriptionTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        uint classId = 999;
        uint instanceId = 999;
        int eventEmittedCount = 0;
        client.Nfa.NfaInstanceChanged += (o, e) => {
            eventEmittedCount++;
            classId = e.classId;
            instanceId = e.instanceId;
            Assert.Multiple(() =>
            {
                Assert.That(e.details, Is.Not.Null);
                Assert.That(e.details?.Owner.ToHuman(), Is.EqualTo("\"5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy\""));
                Assert.That(e.details?.Locked.Value, Is.EqualTo(InnerLocker.None));
            });
        };

        // by new nfa
        (NfaClassId _, NfaInstanceId _) = await NetworkHelpers.ExecBuyNfaMechanic();
        Thread.Sleep(2_000);
        // no event should be
        Assert.That(eventEmittedCount, expression: Is.EqualTo(0));

        // login
        await client.Auth.SignInWithEmailAndPassword("Dave", "password");
        Thread.Sleep(2_000);
        // by new nfa
        (NfaClassId classIdExpected, NfaInstanceId instanceIdExpected) = await NetworkHelpers.ExecBuyNfaMechanic();
        Thread.Sleep(5_000);
        Assert.Multiple(() =>
        {
            Assert.That(eventEmittedCount, Is.AtLeast(1));
            Assert.That(classId, Is.EqualTo(classIdExpected));
            Assert.That(instanceId, Is.EqualTo(instanceIdExpected));
        });
    }
}
