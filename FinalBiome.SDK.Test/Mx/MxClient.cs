using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId;

namespace FinalBiome.Sdk.Test;

public class MxClientTests
{
    [Test]
    public async Task HasNonceAfterLoginTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);
        // if user not signed in, we can't use MxClient
        Assert.Throws<ErrorNotAuthenticatedException>(() => { var _ = client.Mx.accountNonce; });

        await client.Auth.SignInWithEmailAndPassword("dave", "pass");

        Assert.That(client.Mx.accountNonce, Is.AtLeast(0));
    }

    [Test]
    public async Task SuccessExecBuyNfaTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);
        await client.Auth.SignInWithEmailAndPassword("dave", "pass");

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
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);
        await client.Auth.SignInWithEmailAndPassword("dave", "pass");

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
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);
        await client.Auth.SignInWithEmailAndPassword("dave", "pass");

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
    public async Task SuccessExecBetDoubleRounTest()
    {
        // create test nfa and set bettor for it and purchaes characteristic for the ability to buy instance.
        var classId = await NetworkHelpers.CreateNfaClass("bettorNfa");
        await NetworkHelpers.SetCharacteristicBettor(classId, 2);
        await NetworkHelpers.SetCharacteristicPurchased(classId, 1, 3);

        // init api
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);
        await client.Auth.SignInWithEmailAndPassword("dave", "pass");

        // buy nfa for bets
        var resBuy = await client.Mx.ExecBuyNfa(classId, 0);
        var instanceId = (NonFungibleAssetId)resBuy.ResultRaw!.Value2;

        // first round
        var resBet = await client.Mx.ExecBet(classId, instanceId);
        Assert.Multiple(() =>
        {
            Assert.That(resBet.Status, expression: Is.EqualTo(ResultStatus.Stopped));
            Assert.That(resBet.Reason.Data.Outcomes, expression: Has.Count.EqualTo(1));
        });

    }
}
