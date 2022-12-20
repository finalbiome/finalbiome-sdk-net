
using FirebaseAdmin;
using FirebaseAdmin.Auth;

namespace FinalBiome.Sdk.Test;

public class AuthClientTests
{
    [Test]
    public async Task SignInWithEmail()
    {
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();

        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        Assert.That(client.Auth.user, Is.Not.Null);
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
            PersistenceDataPath = Path.GetTempPath(),
            NotAutoLogin = true,
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

    [Test]
    public async Task AnonymSignUp()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));

        byte[]? accountId;
        string newEmail;

        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath(),
        };

        using (Client client = await FinalBiome.Sdk.Client.Create(config))
        {
            Assert.Multiple(() =>
            {
                // here we should be as anonym
                Assert.That(client.Auth.fbClient.User.IsAnonymous, Is.True);
                Assert.That(client.Auth.user, Is.Not.Null);
                Assert.That(client.Auth.UserInfo?.IsAnonymous, Is.True);
            });

            // this device id of anonym
            var deviceId = client.Auth.fbClient.User.Uid;
            accountId = client.Auth.UserAddress.Bytes;

            Assert.That(client.Auth.anonymCredential, Is.Not.Null);

            newEmail = TestUtils.RandomString(8) + "@finalbiome.net";
            string newPwd = TestUtils.RandomString(8);
            await client.Auth.SignUpWithEmailAndPassword(newEmail, newPwd);

            Assert.Multiple(() =>
            {
                Assert.That(client.Auth.user, Is.Not.Null);
                // after singing in user must be the same but non anonym
                Assert.That(client.Auth.anonymCredential, Is.Null);
                Assert.That(client.Auth.fbClient.User.Uid, Is.EqualTo(deviceId));
                Assert.That(client.Auth.UserAddress.Bytes, Is.EqualTo(accountId));
                Assert.That(client.Auth.UserInfo?.IsAnonymous, Is.False);
                Assert.That(client.Auth.UserInfo?.Email, Is.EqualTo(newEmail));
            });
        }

        using (Client client = await FinalBiome.Sdk.Client.Create(config))
        {
            Assert.Multiple(() =>
            {
                // here we should not anonym
                Assert.That(client.Auth.fbClient.User.IsAnonymous, Is.False);
                Assert.That(client.Auth.user, Is.Not.Null);
                Assert.That(client.Auth.UserAddress.Bytes, Is.EqualTo(accountId));
            });
        }

        // cleanup: remove user from the firebase
        var defaultApp = FirebaseApp.Create();
        UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(newEmail);
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(userRecord.Uid);
    }
}
