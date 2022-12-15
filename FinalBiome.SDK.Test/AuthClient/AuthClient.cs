
namespace FinalBiome.Sdk.Test;

public class AuthClientTests
{
    [Test]
    public async Task SignInWithEmail()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

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
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

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

    [Test]
    public async Task PersistenceDataTest()
    {
        // clean any stored user
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));

        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath()
        };
        using (Client client =  await Sdk.Client.Create(config))
        {
            Assert.That(client.Auth.UserIsSet, Is.False);
            // login
            await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
            Assert.That(client.Auth.UserIsSet, Is.True);
        }

        // auth session must be saved between game sessions
        using (Client client =  await Sdk.Client.Create(config))
        {
            Assert.That(client.Auth.UserIsSet, Is.True);
            // login out
            await client.Auth.SignOut();
            Assert.That(client.Auth.UserIsSet, Is.False);

        }
    }
}
