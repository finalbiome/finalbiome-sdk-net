
namespace FinalBiome.Sdk.Test;

public class ClientTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task InitAppTest()
    {
        // clean any stored user
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        
        Assert.Multiple(() =>
        {
            // game data was fetched
            Assert.That(client.Game.Data.Name, Is.EqualTo("WoW"));
            // user is not set
            Assert.That(client.Auth.UserIsSet, Is.EqualTo(false));
        });

        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        Thread.Sleep(2_000);
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
}
