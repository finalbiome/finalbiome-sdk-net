using FinalBiome.Sdk;
namespace FinalBiome.Sdk.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task InitAppTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var client = await FinalBiome.Sdk.Client.Create(config);
        
        Assert.Multiple(() =>
        {
            // game data was fetched
            Assert.That(client.Game.Data.Name, Is.EqualTo("WoW"));
            // user is not set
            Assert.That(client.Auth.UserIsSet, Is.EqualTo(false));
        });

        await client.Auth.SignInWithEmailAndPassword("username", "password");
        Thread.Sleep(5_000);
        Assert.Multiple(() =>
        {
            // user is set here
            Assert.That(client.Auth.UserIsSet, Is.EqualTo(true));
            Assert.That(client.Fa.Balances, Has.Count.EqualTo(2));
        });
        await client.Auth.SignOut();
        Thread.Sleep(2_000);
        Assert.Multiple(() =>
        {
            Assert.That(client.Auth.UserIsSet, Is.EqualTo(false));
            Assert.That(client.Fa.Balances, Is.Empty);
        });
    }

    [Test]
    public async Task StateChangedEventTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var client = await Client.Create(config);

        var wasCalled = false;
        client.Auth.StateChangedEvent += (o,e) => wasCalled = true;

        // login
        await client.Auth.SignInWithEmailAndPassword("username", "password");
        Assert.That(wasCalled, Is.EqualTo(true));

        //logout
        wasCalled = false;
        await client.Auth.SignOut();
        Assert.That(wasCalled, Is.EqualTo(true));

    }
}
