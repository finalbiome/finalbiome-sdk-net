
using System.Numerics;

namespace FinalBiome.Sdk.Test;

public class AuthClientTests
{
    [Test]
    public async Task SignUpWithEmail()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath(),
        };
        using Client client = await Sdk.Client.Create(config);
        Assert.That(await client.Auth.IsLoggedIn(), Is.False);

        await using var user = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);

        Assert.That(await client.Auth.IsLoggedIn(), Is.True);
    }
    
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

        using var wasCalled = new AutoResetEvent(false);
        client.Auth.StateChanged += async (a) =>
        {
            Assert.That(wasCalled.Set(), Is.True);
            await Task.Yield();
        };

        // sign up
        await using var user = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);
        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);

        //logout
        await client.Auth.SignOut();
        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);

        // sign in
        await client.Auth.SignInWithEmailAndPassword(user.Email, user.Password);
        Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
    }

    [Test]
    public async Task PersistenceDataTest()
    {
        // clean any stored user
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));

        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";

        using var wasCalled = new AutoResetEvent(false);

        await using var user = new FirebaseUser();

        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath()
        };

        using (Client client =  await Sdk.Client.Create(config))
        {
            client.Auth.StateChanged += async (a) =>
            {
                Assert.That(wasCalled.Set(), Is.True);
                await Task.Yield();
            };

            Assert.That(await client.Auth.IsLoggedIn(), Is.False);
            // sign up
            await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);

            Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
            Assert.That(await client.Auth.IsLoggedIn(), Is.True);
        }

        ClientConfig config2 = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath()
        };
        
        using (Client client = await Sdk.Client.Create(config2))
        {
            client.Auth.StateChanged += async (a) =>
            {
                Assert.That(wasCalled.Set(), Is.True);
                await Task.Yield();
            };

            Assert.That(await client.Auth.IsLoggedIn(), Is.True);
            Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);

            // login out
            await client.Auth.SignOut();

            Assert.That(await client.Auth.IsLoggedIn(), Is.False);
            Assert.That(wasCalled.WaitOne(TimeSpan.FromSeconds(5)), Is.True);
        }
    }

    [Test]
    public async Task AnonymSignUp()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        await using var user = new FirebaseUser();

        byte[]? accountId;

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
                Assert.That(client.Auth.SignUpSignature, expression: Is.Null);
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

            await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);

            Assert.Multiple(() =>
            {
                Assert.That(client.Auth.Account, Is.Not.Null);
                // after singing in user must be the same but non anonym
                Assert.That(client.Auth.User!.IsAnonymous, Is.False);
                Assert.That(client.Auth.fbClient.User.Uid, Is.EqualTo(deviceId));
                Assert.That(client.Auth.UserAddress.Bytes, Is.EqualTo(accountId));
                Assert.That(client.Auth.UserInfo?.IsAnonymous, Is.False);
                Assert.That(client.Auth.UserInfo?.Email, Is.EqualTo(user.Email));
                Assert.That(client.Auth.SignUpSignature, Is.Null);
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
    }

    [Test]
    public async Task Logout()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        // create a new firebase user and make sign up
        await using var user = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user.Email, user.Password);
        Assert.Multiple(async () =>
        {
            Assert.That(await client.Auth.IsLoggedIn(), Is.True);
            Assert.That(client.Auth.User, Is.Not.Null);
            Assert.That(client.Auth.UserAddress, Is.Not.Null);
            Assert.That(client.Auth.UserInfo, Is.Not.Null);
        });
        // wait login initialization
        Thread.Sleep(1_000);

        await client.Auth.SignOut();
        Assert.Multiple(() =>
        {

            // Assert.That(await client.Auth.IsLoggedIn(), Is.False);
            Assert.That(client.Auth.User, Is.Null);
            Assert.That(client.Auth.UserInfo, Is.Null);
        });
    }

    [Test]
    public async Task LogoutWithChangingAccount()
    {
        // force logout
        File.Delete(Path.Combine(Path.GetTempPath(), "finalbiome_auth.json"));
        using Client client = await NetworkHelpers.GetSdkClientForEveGame();
        // create a new firebase user and make sign up
        await using var user1 = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user1.Email, user1.Password);

        var user1Account = client.Auth.Signer.AccountId.Bytes;
        // try to make some tx
        await client.Mx.OnboardToGame();
        // assert that user can makes any transactions because they have some balance after signing up to the network.
        using Api.Client api = await Api.Client.New();
        var info1 = await api.Storage.System.Account(client.Auth.UserAddress).Fetch();
        Assert.That(info1!.Data.Free.Value, Is.GreaterThan(BigInteger.Zero));

        // logout
        await client.Auth.SignOut();

        // create a new firebase user and make sign up
        await using var user2 = new FirebaseUser();
        await client.Auth.SignUpWithEmailAndPassword(user2.Email, user2.Password);

        var user2Account = client.Auth.Signer.AccountId.Bytes;

        Assert.That(user2Account, Is.Not.EqualTo(user1Account));

        // try to make some tx
        await client.Mx.OnboardToGame();
        // assert that user can makes any transactions because they have some balance after signing up to the network.
        var info2 = await api.Storage.System.Account(client.Auth.UserAddress).Fetch();
        Assert.That(info2!.Data.Free.Value, Is.GreaterThan(BigInteger.Zero));

        // login as first user
        // await client.Auth.SignUpWithEmailAndPassword(user1.Email, user1.Password);

    }

}
