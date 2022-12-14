
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
}
