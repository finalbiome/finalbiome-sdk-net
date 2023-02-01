using System.Numerics;
using FinalBiome.Api.Types.PalletSupport;
using FinalBiome.Api.Types.SpCore.Crypto;

namespace FinalBiome.Sdk.Test;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
public class NfaClientTests
{
    [Test]
    public async Task GetClassDetailsTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        var classId = 0u;
        var details = await client.Nfa.GetClassDetails(classId);
        Assert.That(details, Is.Not.Null);
        Assert.That(details.Name.ToHuman(), Is.EqualTo("\"Stave\""));
    }

    [Test]
    public async Task GetClassDetailsNotFoundTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

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
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        // login (it's not necessary to get instance details, but need to the helper for buying nfa)
        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        // by new nfa
        (NfaClassId classId, NfaInstanceId instanceId) = await NetworkHelpers.ExecBuyNfaMechanic(client.Auth.Signer);

        var details = await client.Nfa.GetInstanceDetails(classId, instanceId);
        Assert.Multiple(() =>
        {
            Assert.That(details, Is.Not.Null);
            Assert.That(details.Owner.ToHuman(), Is.EqualTo(client.Auth.GamerAccount.AccountId.ToHuman()));
            Assert.That(details.Locked.Value, Is.EqualTo(InnerLocker.None));
        });
    }

    [Test]
    public async Task GetInstanceDetailsNotFoundTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        var classId = 0u;
        var instanceId = 9999u;
        Assert.ThrowsAsync<NfaInstanceNotFoundException>(() => client.Nfa.GetInstanceDetails(classId, instanceId));
    }
    
    [Test]
    public async Task ClassSubscriptionTest()
    {
        // for test events about changes of nfs classes, we create a test attribute and listen changes on the nfa class.
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        var classId = 0u;
        using var wasCalled = new AutoResetEvent(false);
        int eventEmittedCount = 0;
        client.Nfa.NfaClassChanged += (o, e) =>
        {
            Assert.That(wasCalled.Set(), Is.True);
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
        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);


        Assert.Multiple(() =>
        {
            Assert.That(details?.Attributes.Value, Is.EqualTo(9));
            Assert.That(eventEmittedCount, Is.EqualTo(1));
        });


        // create attr. it should emit event from subscription
        await NetworkHelpers.CreateClassAttribute(classId, "testAttr", "testVal");

        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
        Assert.That(eventEmittedCount, Is.EqualTo(2));

        //cleanup
        await NetworkHelpers.RemoveClassAttribute(classId, "testAttr");
        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
        Assert.That(eventEmittedCount, Is.EqualTo(3));
    }

    [Test]
    public async Task NewAssetsSubscriptionTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        uint classId = 999;
        uint instanceId = 999;
        using var wasCalled = new AutoResetEvent(false);
        client.Nfa.NfaInstanceChanged += (o, e) => {
            Assert.That(wasCalled.Set(), Is.True);
            classId = e.classId;
            instanceId = e.instanceId;
            Assert.That(e.details, Is.Not.Null);
        };

        // login
        await using var user = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);
        await client.Mx.OnboardToGame();
       
        // by new nfa
        (NfaClassId classIdExpected, NfaInstanceId instanceIdExpected) = await NetworkHelpers.ExecBuyNfaMechanic(client.Auth.Signer);

        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
        Assert.That(classId, Is.EqualTo(classIdExpected));
        Assert.That(instanceId, Is.EqualTo(instanceIdExpected));
    }

    [Test]
    public async Task SignUpToNetworkTest()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        AccountId32? account;
        using (Client client = await NetworkHelpers.GetSdkClientForEveGame())
        {
            // create a new firebase user and make sign up
            await using var user = new FirebaseUser();
            await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);

            Assert.That(await client.Auth.IsLoggedIn(), Is.True);
            account = client.Auth.UserAddress;
        }

        // assert that user can makes any transactions because they have some balance after signing up to the network.
        using Api.Client api = await Api.Client.New();
        var info = await api.Storage.System.Account(account).Fetch();
        Assert.That(info!.Data.Free.Value, Is.GreaterThan(BigInteger.Zero));
    }
}
