
using FirebaseAdmin;
using FirebaseAdmin.Auth;

namespace FinalBiome.Sdk.Test;

public class GameClientTest
{
    [Test]
    public async Task IsOnboarded()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));

        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath()
        };

        using Client client = await Sdk.Client.Create(config);

        Assert.That(client.Game.IsOnboarded, Is.False);

        // login
        string newEmail = TestUtils.RandomString(8) + "@finalbiome.net";
        string newPwd = TestUtils.RandomString(8);
        await client.Auth.SignUpWithEmailAndPassword(newEmail, newPwd);

        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());
        
        Assert.That(client.Game.IsOnboarded, Is.False);

        // check method FetchIsOnboarded. it's need because the next OnboardToGame method doesn't call FetchIsOnboarded
        var r1 = await client.Game.FetchIsOnboarded();
        Assert.That(r1, Is.False);

        await client.Mx.OnboardToGame();

        // check method FetchIsOnboarded
        var r2 = await client.Game.FetchIsOnboarded();
        Assert.That(r2, Is.True);

        Assert.That(client.Game.IsOnboarded, Is.True);

        await client.Auth.SignOut();

        Assert.That(client.Game.IsOnboarded, Is.Null);

        // cleanup: remove user from the firebase
        var defaultApp = FirebaseApp.Create();
        UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(newEmail);
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(userRecord.Uid);

    }
}
