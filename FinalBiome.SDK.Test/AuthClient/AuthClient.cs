
namespace FinalBiome.Sdk.Test;

public class AuthClientTests
{
    [Test]
    public async Task SignInWithEmail()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        await client.Auth.SignInWithEmailAndPassword("sergey@weedydidie.com", "Qq123456");

        Assert.That(client.Auth.fbUser, Is.Not.Null);
        Assert.That(client.Auth.seed, Is.Not.Null);
    }
}
