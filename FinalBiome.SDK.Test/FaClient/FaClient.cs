
namespace FinalBiome.Sdk.Test;

public class FaClientTests
{
    [Test]
    public async Task ClientNotifiedAboutBalances()
    {
        // clean any stored user
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        
        // init api
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        Assert.That(client.Fa.Balances, Is.Empty);

        using var wasCalled = new AutoResetEvent(false);
        uint? updatedFa = null;
        client.Fa.FaBalanceChanged += (o, e) =>
        {
            Assert.That(wasCalled.Set(), Is.True);
            updatedFa = e.Id;
        };

        if (!await client.Auth.IsLoggedIn()) await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.Account!.ToAddress());

        Assert.That(client.Fa.Balances, Has.Count.EqualTo(2));
        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);

        Assert.That(updatedFa, Is.Not.Null);
        Assert.That(client.Fa.Balances[(uint)updatedFa!], Is.AtLeast(0));

    }
}
