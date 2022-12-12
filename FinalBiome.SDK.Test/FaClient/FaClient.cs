
namespace FinalBiome.Sdk.Test;

public class FaClientTests
{
    [Test]
    public async Task ClientNotifiedAboutBalances()
    {
        // init api
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        Assert.That(client.Fa.Balances, Is.Empty);

        int eventEmittedCount = 0;
        uint? updatedFa = null;
        client.Fa.FaBalanceChanged += (o, e) =>
        {
            eventEmittedCount++;
            updatedFa = e.Id;
        };

        await client.Auth.SignInWithEmailAndPassword("username", "password");
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
