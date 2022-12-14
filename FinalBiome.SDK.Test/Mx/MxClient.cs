using FinalBiome.Api.Types.PalletMechanics.Types;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId;

namespace FinalBiome.Sdk.Test;

public class MxClientTests
{
    [Test]
    public async Task HasNonceAfterLoginTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        // if user not signed in, we can't use MxClient
        Assert.Throws<ErrorNotAuthenticatedException>(() => { var _ = client.Mx.accountNonce; });

        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        Assert.That(client.Mx.accountNonce, Is.AtLeast(0));
    }

    [Test]
    public async Task SuccessExecBuyNfaTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        var currNonce = client.Mx.accountNonce;
        var res = await client.Mx.ExecBuyNfa(0, 0);
        Assert.Multiple(() =>
        {
            Assert.That(res.Status, expression: Is.EqualTo(ResultStatus.Finished));
            Assert.That(client.Mx.accountNonce, Is.EqualTo(currNonce + 1));
            Assert.That(res.Result.InstanceId, Is.AtLeast(0));
        });
    }

    [Test]
    public async Task FailedExecBuyNfaTest()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        var currNonce = client.Mx.accountNonce;

        try {
            var res = await client.Mx.ExecBuyNfa(0, 999);
        }
        catch (Exception) { }
        Assert.That(client.Mx.accountNonce, Is.EqualTo(currNonce + 1));

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
        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

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
        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        // buy nfa for bets
        var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
        var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

        // first round
        var resBet = await client.Mx.ExecBet(classId, instanceId);
        Assert.Multiple(() =>
        {
            Assert.That(resBet.Status, Is.EqualTo(ResultStatus.Stopped));
            Assert.That(resBet.Reason.Data.Outcomes, Has.Count.EqualTo(1));
        });
        // TODO: ...
        // second round
        var resBet2 = await client.Mx.UpgradeBet(resBet.Id);
        Assert.Multiple(() =>
        {
            Assert.That(resBet2.Status, Is.EqualTo(ResultStatus.Finished));
            Assert.That(resBet2.Result.Outcomes, Has.Count.EqualTo(2));
        });
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
        ClientConfig config = new(eveGame);

        MxResultBet resBet;
        using (Client client = await Client.Create(config))
        {
            await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
            // check balance for the gamer for the ability to make game transactions
            await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

            // buy nfa for bets
            var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
            var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

            // first round
            resBet = await client.Mx.ExecBet(classId, instanceId);
        }

        // create new api
        using Client client2 = await NetworkHelpers.GetSdkClientForEveGame();
        await client2.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client2.Auth.user!.ToAddress());

        Thread.Sleep(1_000);

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
        await client1.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client1.Auth.user!.ToAddress());

        using Client client2 = await NetworkHelpers.GetSdkClientForEveGame();
        await client2.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client2.Auth.user!.ToAddress());

        Thread.Sleep(100); // need to check why

        Assert.That(client1.Mx.accountNonce, Is.EqualTo(client2.Mx.accountNonce));

        // buy nfa by the client1
        var res1 = await client1.Mx.ExecBuyNfa(0, 0);
        Assert.Multiple(() =>
        {
            Assert.That(res1.Status, expression: Is.EqualTo(ResultStatus.Finished));
            Assert.That(client1.Mx.accountNonce, Is.EqualTo(client2.Mx.accountNonce + 1));
        });

        // buy second nfa by the client2
        var res2 = await client2.Mx.ExecBuyNfa(0, 0);
        Assert.That(res2.Status, expression: Is.EqualTo(ResultStatus.Finished));
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
        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        // buy nfa for bets
        var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
        var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

        MxId? mxId = null;
        MechanicDetails? details = null;
        int eventEmittedCount = 0;
        client.Mx.MechanicsChanged += (o, e) => {
            eventEmittedCount++;
            mxId = e.Id;
            details = e.Details;
        };

        var res = await client.Mx.ExecBet(classId, instanceId);
        MxId expectedMxId = res.Id;
        var expectedDetails = res.Reason;
        Assert.Multiple(() =>
        {
            Assert.That(eventEmittedCount, Is.EqualTo(1));
            Assert.That(mxId?.nonce, Is.EqualTo(expectedMxId.nonce));
            Assert.That(mxId?.gamerAccount.OrganizationId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.OrganizationId.Bytes));
            Assert.That(mxId?.gamerAccount.AccountId.Bytes, Is.EqualTo(expectedMxId.gamerAccount.AccountId.Bytes));
            Assert.That(details, Is.Not.Null);
        });

        // last round
        var fin = await client.Mx.UpgradeBet(expectedMxId);
        Assert.Multiple(() =>
        {
            Assert.That(eventEmittedCount, Is.EqualTo(2));
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
        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

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
}
