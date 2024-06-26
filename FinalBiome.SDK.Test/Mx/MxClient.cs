using FinalBiome.Api.Types.PalletMechanics.Types;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId;

namespace FinalBiome.Sdk.Test;

public class MxClientTests
{
    [Test]
    public async Task HasNonceAfterLoginTest()
    {
        // clean any stored user
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        // if user not signed in, we can't use MxClient
        Assert.ThrowsAsync<ErrorNotAuthenticatedException>(async () => { var _ = await client.Mx.MxSubmitter.GetAccountNonce(); });

        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        Assert.That(await client.Mx.MxSubmitter.GetAccountNonce(), Is.AtLeast(0));
    }

    [Test]
    public async Task SuccessExecBuyNfaTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        var currNonce = await client.Mx.MxSubmitter.GetAccountNonce();
        var res = await client.Mx.ExecBuyNfa(0, 0);
        Assert.That(res.Status, expression: Is.EqualTo(ResultStatus.Finished));
        Assert.That(await client.Mx.MxSubmitter.GetAccountNonce(), Is.EqualTo(currNonce + 1));
        Assert.That(res.Result.InstanceId, Is.AtLeast(0));
    }

    [Test]
    public async Task FailedExecBuyNfaTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        var currNonce = await client.Mx.MxSubmitter.GetAccountNonce();

        try {
            var res = await client.Mx.ExecBuyNfa(0, 999);
        }
        catch (Exception) { }
        Assert.That(await client.Mx.MxSubmitter.GetAccountNonce(), Is.EqualTo(currNonce + 1));

    }

    [Test]
    public async Task SuccessExecBetSingleRoundTest()
    {
        // create test nfa and set bettor for it and purchaes characteristic for the ability to buy instance.
        var classId = await NetworkHelpers.CreateNfaClass("bettorNfa");
        await NetworkHelpers.SetCharacteristicBettor(classId, 1);
        await NetworkHelpers.SetCharacteristicPurchased(classId, 1, 3);

        // init api
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        // buy nfa for bets
        var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
        var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

        var resBet = await client.Mx.ExecBet(classId, instanceId);
        Assert.Multiple(() =>
        {
            Assert.That(resBet.Status, expression: Is.EqualTo(ResultStatus.Finished));
            Assert.That(resBet.Result.Outcomes, expression: Has.Count.AtLeast(1));
        });
    }

    [Test]
    public async Task SuccessExecBetDoubleRoundTest()
    {
        // create test nfa and set bettor for it and purchaes characteristic for the ability to buy instance.
        var classId = await NetworkHelpers.CreateNfaClass("bettorNfa");
        await NetworkHelpers.SetCharacteristicBettor(classId, 2);
        await NetworkHelpers.SetCharacteristicPurchased(classId, 1, 3);

        // init api
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        await using var user = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);
        Assert.That(await client.Auth.IsLoggedIn(), Is.True);
        await client.Mx.OnboardToGame();

        // buy nfa for bets
        var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
        var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

        // first round
        var resBet = await client.Mx.ExecBet(classId, instanceId);
        Assert.That(resBet.Status, Is.EqualTo(ResultStatus.Stopped));
        Assert.That(resBet.Reason.Data.Outcomes, Has.Count.EqualTo(1));

        // second round
        var resBet2 = await client.Mx.UpgradeBet(resBet.Id);
        Assert.That(resBet2.Status, Is.EqualTo(ResultStatus.Finished));
        Assert.That(resBet2.Result.Outcomes, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task MxClientFetchActiveMxWhenInit()
    {
        // create test nfa and set bettor for it and purchaes characteristic for the ability to buy instance.
        var classId = await NetworkHelpers.CreateNfaClass("bettorNfa");
        await NetworkHelpers.SetCharacteristicBettor(classId, 2);
        await NetworkHelpers.SetCharacteristicPurchased(classId, 1, 3);

        // init api
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath(),
        };

        MxResultBet resBet;
        using (Client client = await Client.Create(config))
        {
            if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

            // buy nfa for bets
            var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
            var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

            // first round
            resBet = await client.Mx.ExecBet(classId, instanceId);
        }

        // create new api
        using Client client2 = await NetworkHelpers.GetSdkClientForEveGame();
        if (!await client2.Auth.IsLoggedIn()) await client2.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        Assert.That(client2.Mx.activeMechanics, Has.Count.AtLeast(1));
        // any acvive mechanics has the same gamer account
        foreach (var (mxid, details) in client2.Mx.activeMechanics)
        {
            Assert.Multiple(() =>
            {
                Assert.That(mxid.gamerAccount.OrganizationId.Bytes, Is.EqualTo(client2.config.GameAccount.Bytes));
                Assert.That(mxid.gamerAccount.AccountId.Bytes, Is.EqualTo(client2.Auth.UserAddress.Bytes));
            });
        }

        // acvive mechanics must have the mechanics which was created before
        Assert.That(client2.Mx.activeMechanics.Where(m => {
            return m.Key.nonce == resBet.Id.nonce;
        }).ToList(), Has.Count.EqualTo(1));
    }

    [Test]
    public async Task MxClientMustHandleWrongNonce()
    {
        // init two clients, exec mx in the first client and try exec other mx in the second one.
        using Client client1 = await NetworkHelpers.GetSdkClientForEveGame();
        if (!await client1.Auth.IsLoggedIn()) await client1.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        using Client client2 = await NetworkHelpers.GetSdkClientForEveGame();
        if (!await client2.Auth.IsLoggedIn()) await client2.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        Assert.That(await client1.Mx.MxSubmitter.GetAccountNonce(), Is.EqualTo(await client2.Mx.MxSubmitter.GetAccountNonce()));

        // buy nfa by the client1
        var res1 = await client1.Mx.ExecBuyNfa(0, 0);
        Assert.That(res1.Status, Is.EqualTo(ResultStatus.Finished));
        Assert.That(await client1.Mx.MxSubmitter.GetAccountNonce(), Is.EqualTo(await client2.Mx.MxSubmitter.GetAccountNonce() + 1));

        // buy second nfa by the client2
        var res2 = await client2.Mx.ExecBuyNfa(0, 0);
        Assert.That(res2.Status, Is.EqualTo(ResultStatus.Finished));
    }

    [Test]
    public async Task MechanicsChangedEventTest()
    {
        // create test nfa and set bettor for it and purchaes characteristic for the ability to buy instance.
        var classId = await NetworkHelpers.CreateNfaClass("bettorNfa");
        await NetworkHelpers.SetCharacteristicBettor(classId, 2);
        await NetworkHelpers.SetCharacteristicPurchased(classId, 1, 3);
        // init api
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        // create a new firebase user and make sign up
        await using var user = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);
        await client.Mx.OnboardToGame();
        // buy nfa for bets
        var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
        var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

        MxId? mxId = null;
        MechanicDetails? details = null;
        using var wasCalled = new AutoResetEvent(false);

        client.Mx.MechanicsChanged += (o, e) => {
            Assert.That(wasCalled.Set(), Is.True);
            mxId = e.Id;
            details = e.Details;
        };

        var res = await client.Mx.ExecBet(classId, instanceId);
        MxId expectedMxId = res.Id;
        var expectedDetails = res.Reason;

        Assert.Multiple(() =>
        {
            Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
            Assert.That(mxId?.nonce, Is.EqualTo(expectedMxId.nonce));
            Assert.That(mxId?.gamerAccount.OrganizationId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.OrganizationId.Bytes));
            Assert.That(mxId?.gamerAccount.AccountId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.AccountId.Bytes));
            Assert.That(details, Is.Not.Null);
        });

        // last round
        var fin = await client.Mx.UpgradeBet(expectedMxId);
        Assert.Multiple(() =>
        {
            Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
            Assert.That(mxId?.nonce, Is.EqualTo(expectedMxId.nonce));
            Assert.That(mxId?.gamerAccount.OrganizationId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.OrganizationId.Bytes));
            Assert.That(mxId?.gamerAccount.AccountId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.AccountId.Bytes));
            Assert.That(details, Is.Null);
        });

    }

    [Test]
    [Ignore("It's long test (5 min wait. Not necessary run it every time")]
    public async Task DroppedByTimeutRaiseEvent()
    {
        // create test nfa and set bettor for it and purchaes characteristic for the ability to buy instance.
        var classId = await NetworkHelpers.CreateNfaClass("bettorNfa");
        await NetworkHelpers.SetCharacteristicBettor(classId, 2);
        await NetworkHelpers.SetCharacteristicPurchased(classId, 1, 3);
        // init api
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

        // buy nfa for bets
        var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
        var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

        MxId? mxId = null;
        int eventEmittedCount = 0;
        client.Mx.MechanicsDropped += (o, e) => {
            eventEmittedCount++;
            mxId = e.Id;
        };
        // exec first round and wait to timeont
        var res = await client.Mx.ExecBet(classId, instanceId);
        MxId expectedMxId = res.Id;

        Thread.Sleep(300_000);
        Assert.Multiple(() =>
        {
            Assert.That(eventEmittedCount, Is.EqualTo(1));
            Assert.That(mxId?.nonce, Is.EqualTo(expectedMxId.nonce));
            Assert.That(mxId?.gamerAccount.OrganizationId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.OrganizationId.Bytes));
            Assert.That(mxId?.gamerAccount.AccountId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.AccountId.Bytes));
        });
    }

    [Test]
    public async Task SignInWithOnboarding()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();


        client.Auth.StateChanged += async (isLoggedIn) =>
        {
            // try to make some tx. Tx can't be failing with account balance too low error
            await client.Mx.OnboardToGame();
        };

        // login as anonym
        await client.Auth.SignInAsAnonym();
    }
}
