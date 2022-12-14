
namespace FinalBiome.Sdk.Test;

public class AuthClientTests
{
    [Test]
    public async Task SignInWithEmail()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        Assert.Multiple(() =>
        {
            Assert.That(client.Auth.user, Is.Not.Null);
        });
        await client.Auth.SignOut();
        Assert.Multiple(() =>
        {
            Assert.That(client.Auth.user, Is.Null);
        });
    }

    [Test]
    public async Task StateChangedEventTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        var wasCalled = false;
        client.Auth.StateChanged += async (a) => {
            wasCalled = true;
            await Task.Yield();
        };

        // login
        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        Assert.That(wasCalled, Is.EqualTo(true));

        //logout
        wasCalled = false;
        await client.Auth.SignOut();
        Assert.That(wasCalled, Is.EqualTo(true));
    }
}
