
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

        int eventEmittedCount = 0;
        uint? updatedFa = null;
        client.Fa.FaBalanceChanged += (o, e) =>
        {
            eventEmittedCount++;
            updatedFa = e.Id;
        };

        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        Thread.Sleep(1_500);
        Assert.Multiple(() =>
        {
            Assert.That(client.Fa.Balances, Has.Count.EqualTo(2));
            Assert.That(eventEmittedCount, Is.AtLeast(1));
            Assert.That(updatedFa, Is.Not.Null);
            Assert.That(client.Fa.Balances[(uint)updatedFa!], Is.AtLeast(0));
        });

    }
}
