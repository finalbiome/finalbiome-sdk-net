
using FirebaseAdmin;
using FirebaseAdmin.Auth;

namespace FinalBiome.Sdk.Test;

public class AuthClientTests
{
    [Test]
    public async Task SignInWithEmail()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));

        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath(),
        };

        using (Client client = await Sdk.Client.Create(config))
        {
            Assert.That(await client.Auth.IsLoggedIn(), Is.False);
            await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
            Assert.Multiple(async () =>
            {
                Assert.That(await client.Auth.IsLoggedIn(), Is.True);
                Assert.That(client.Auth.Account, Is.Not.Null);
            });
        }

        // the same with persisted credentials
        using (Client client = await Sdk.Client.Create(config))
        {
            Assert.Multiple(async () =>
            {
                Assert.That(await client.Auth.IsLoggedIn(), Is.True);
                Assert.That(client.Auth.Account, Is.Not.Null);
            });
            await client.Auth.SignOut();

            Assert.Multiple(async () =>
            {
                Assert.That(await client.Auth.IsLoggedIn(), Is.False);
                Assert.That(client.Auth.Account, Is.Null);
            });
        }

        // the same with persisted credentials and logged out
        using (Client client = await Sdk.Client.Create(config))
        {
            Assert.Multiple(async () =>
            {
                Assert.That(await client.Auth.IsLoggedIn(), Is.False);
                Assert.That(client.Auth.Account, Is.Null);
            });
        }
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

        int eventEmittedCount = 0;

        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath()
        };

        using (Client client =  await Sdk.Client.Create(config))
        {
            
            client.Auth.StateChanged += async (a) => {
                eventEmittedCount++;
                await Task.Yield();
            };

            Assert.That(await client.Auth.IsLoggedIn(), Is.False);
            // login
            await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");

            Assert.That(await client.Auth.IsLoggedIn(), Is.True);
            Assert.That(eventEmittedCount, Is.EqualTo(1));

        }

        // auth session must be saved between game sessions
        eventEmittedCount = 0;

        ClientConfig config2 = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath()
        };
        
        using (Client client = await Sdk.Client.Create(config2))
        {
            client.Auth.StateChanged += async (a) => {
                Console.WriteLine($"Outer Invoke StateChanged 1");
                eventEmittedCount++;
                await Task.Yield();
            };

            Assert.That(await client.Auth.IsLoggedIn(), Is.True);
            Assert.That(eventEmittedCount, Is.EqualTo(1));

            // login out
            await client.Auth.SignOut();

            Assert.That(await client.Auth.IsLoggedIn(), Is.False);
            Assert.That(eventEmittedCount, Is.EqualTo(2));
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
            Assert.That(await client.Auth.IsLoggedIn(), Is.False);
            Assert.Multiple(() =>
            {
                // here we should be as anonym
                Assert.That(client.Auth.Account, Is.Null);
                Assert.That(client.Auth.UserInfo, expression: Is.Null);
            });

            await client.Auth.SignInAsAnonym();

            Assert.Multiple(() =>
            {
                // here we should be as anonym
                Assert.That(client.Auth.fbClient.User.IsAnonymous, Is.True);
                Assert.That(client.Auth.Account, Is.Not.Null);
                Assert.That(client.Auth.UserInfo?.IsAnonymous, Is.True);
            });

            // this device id of anonym
            var deviceId = client.Auth.fbClient.User.Uid;
            accountId = client.Auth.UserAddress.Bytes;

            Assert.That(client.Auth.User!.IsAnonymous, Is.True);

            newEmail = TestUtils.RandomString(8) + "@finalbiome.net";
            string newPwd = TestUtils.RandomString(8);

            await client.Auth.SignUpWithEmailAndPassword(newEmail, newPwd);

            Assert.Multiple(() =>
            {
                Assert.That(client.Auth.Account, Is.Not.Null);
                // after singing in user must be the same but non anonym
                Assert.That(client.Auth.User.IsAnonymous, Is.False);
                Assert.That(client.Auth.fbClient.User.Uid, Is.EqualTo(deviceId));
                Assert.That(client.Auth.UserAddress.Bytes, Is.EqualTo(accountId));
                Assert.That(client.Auth.UserInfo?.IsAnonymous, Is.False);
                Assert.That(client.Auth.UserInfo?.Email, Is.EqualTo(newEmail));
            });
        }

        using (Client client = await FinalBiome.Sdk.Client.Create(config))
        {
            Assert.That(await client.Auth.IsLoggedIn(), Is.True);

            Assert.Multiple(() =>
            {
                // here we should not anonym
                Assert.That(client.Auth.fbClient.User.IsAnonymous, Is.False);
                Assert.That(client.Auth.Account, Is.Not.Null);
                Assert.That(client.Auth.UserAddress.Bytes, Is.EqualTo(accountId));
            });
        }

        // cleanup: remove user from the firebase
        var defaultApp = FirebaseApp.Create();
        UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(newEmail);
        await FirebaseAuth.DefaultInstance.DeleteUserAsync(userRecord.Uid);
    }
}
