
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
}
