namespace FinalBiome.Sdk.Test;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;

public class NetworkEventsListenerTests
{
    [Test]
    public async Task NetworkEvenstsListenTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        using CancellationTokenSource cts = new();
        using NetworkEventsListener l = new(client);

        // login
        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.Account!.ToAddress());

        Thread.Sleep(1_000);

        uint classId = 999;
        uint instanceId = 999;
        int eventEmittedCount = 0;
        l.NfaIssued += async (c, i) => {
            eventEmittedCount++;
            classId = c;
            instanceId = i;
            await Task.Yield();
        };

        await l.StartNetworkEventsListener();
        Thread.Sleep(2_000);
        Assert.That(eventEmittedCount, Is.EqualTo(0));

        // by new nfa
        (NfaClassId classIdExpected, NfaInstanceId instanceIdExpected) = await NetworkHelpers.ExecBuyNfaMechanic(client.Auth.Signer);
        Thread.Sleep(2_000);
        
        Assert.Multiple(() =>
        {
            Assert.That(eventEmittedCount, Is.EqualTo(1));
            Assert.That(classId, Is.EqualTo(classIdExpected));
            Assert.That(instanceId, Is.EqualTo(instanceIdExpected));
        });
        eventEmittedCount = 0;
        await l.StopNetworkEventsListener();
        Thread.Sleep(2_000);
        Assert.That(eventEmittedCount, Is.EqualTo(0));
        Thread.Sleep(2_000);
    }
}
