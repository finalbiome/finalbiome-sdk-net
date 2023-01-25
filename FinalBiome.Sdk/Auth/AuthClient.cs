using FinalBiome.Api.Tx;
using FinalBiome.Sdk.Jimmy;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Requests;

namespace FinalBiome.Sdk;

using GamerAccount = Api.Types.PalletSupport.GamerAccount;

public class AuthClient
{
    readonly Client client;

    readonly Jimmy.JimmyClient jimmyClient;

    /// <summary>
    /// Current FinalBiome user.
    /// </summary>
    internal Api.Tx.Account? Account { get; set; }

    /// <summary>
    /// The user address in the network.
    /// Throw error ErrorNotAuthenticatedException if user not set.
    /// </summary>
    /// <value></value>
    public Api.Types.SpCore.Crypto.AccountId32 UserAddress
    {
        get
        {
            if (Account is null) throw new ErrorNotAuthenticatedException();
            return Account;
        }
    }

    PairSigner? _signer;
    internal PairSigner Signer
    {
        get
        {
            if (Account is null) throw new ErrorNotAuthenticatedException();
            _signer ??= new PairSigner(Account);
            return _signer;
        }
    }

    GamerAccount? _gamerAccount;
    internal GamerAccount GamerAccount
    {
        get
        {
            if (Account is null) throw new ErrorNotAuthenticatedException();
            if (_gamerAccount is null)
            {
                _gamerAccount = new GamerAccount();
                _gamerAccount.Init(
                    UserAddress.Encode()
                    .Concat(this.client.config.GameAccount.Encode())
                    .ToArray()
                );
            }
            return _gamerAccount;
        }
    }

    /// <summary>
    /// Signature for registration in the quota management system.
    /// </summary>
    /// <value></value>
    internal byte[]? SignUpSignature { get; set; }

    private User? _user;

    public User? User
    {
        get
        {
            if (fbClient.User is not null) return fbClient.User;
            return _user;
        }
        internal set
        {
            _user = value;
        }
    }

    bool firebaseAuthInitialized = false;

    private UserInfo? _userInfo;
    /// <summary>
    /// Information about current user.
    /// </summary>
    /// <value></value>
    public UserInfo? UserInfo
    {
        get
        {
            if (User is not null) return User.Info;
            return _userInfo;
        }
        set
        {
            _userInfo = value;
        }
    }

    /// <summary>
    /// A delegate type that will invoke when state of the user has been changed
    /// </summary>
    /// <param name="loggedIn">true - logged in</param>
    /// <returns></returns>
    public delegate Task OnStateChanged(bool loggedIn);
    /// <summary>
    /// This event gets called whenever the user's account changes.
    /// </summary>
    public OnStateChanged? StateChanged;

    internal readonly FirebaseAuthClient fbClient;
    private readonly FirebaseAuthConfig fbConfig;

    public AuthClient(Client client)
    {
        this.client = client;
        jimmyClient = new();
        // init firebase client
        FirebaseAuthConfig config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyAPXCxpiWb3QKW4xSL1bej4gQRxVu--l5I",
            AuthDomain = "finalbiome-jimmy.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                new EmailProvider(),
            }
        };
        // if sets the path for persistence, init file repository for storing auth data.
        if (!string.IsNullOrWhiteSpace(client.config.PersistenceDataPath))
        {
            FileUserRepository repository = new(client.config.PersistenceDataPath);
            config.UserRepository = repository;
        }

        this.fbConfig = config;
        this.fbClient = new(config);
    }

    private void InitFirebaseAuthClient()
    {
        if (!firebaseAuthInitialized)
        {
            this.fbClient.AuthStateChanged += FbAuthStateHandler;
            firebaseAuthInitialized = true;
        }
    }
    /// <summary>
    /// Indicates whether a user account is set or not <br/>
    /// This can be interpreted as whether the user is logged in or not.
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsLoggedIn()
    {
        if (Account is not null) return true;

        InitFirebaseAuthClient();

        // try to get persisted credentials and if it exists, init account
        if (await GetUserInfo())
        {
            if (UserInfo!.IsAnonymous)
            {
                await FetchSeedAsAnonymous().ConfigureAwait(false);
            }
            else
            {
                await FetchSeedByFbAuth().ConfigureAwait(false);
            }
        }

        return Account is not null;
    }
    /// <summary>
    /// Sing in user with email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task SignInWithEmailAndPassword(string email, string password)
    {
        InitFirebaseAuthClient();

        var credential = await fbClient.SignInWithEmailAndPasswordAsync(email, password).ConfigureAwait(false);
        User = credential.User;
        await FetchSeedByFbAuth().ConfigureAwait(false);
    }

    /// <summary>
    /// Notifies internal clients about user state changing
    /// </summary>
    /// <returns></returns>
    async Task NotifyStateChanges(bool isLogged)
    {
        List<Task> tasks = new()
        {
            client.networkEventsListener.HandleUserStateChangedEvent(isLogged),
            client.Fa.HandleUserStateChangedEvent(isLogged),
            client.Nfa.HandleUserStateChangedEvent(isLogged),
            client.Game.HandleUserStateChangedEvent(isLogged),
            client.Mx.HandleUserStateChangedEvent(isLogged)
        };

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    /// <summary>
    /// Sign up user with email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task SignUpWithEmailAndPassword(string email, string password)
    {
        InitFirebaseAuthClient();

        var result = await fbClient.FetchSignInMethodsForEmailAsync(email);
        if (result.UserExists) throw new Exception($"User with {email} email already exists.Tyr to sign in");


        // if user anonym migrate seed, else create new
        if (User is not null && User.IsAnonymous)
        {
            var credential = EmailProvider.GetCredential(email, password);
            var userCredential = await User.LinkWithCredentialAsync(credential);
            User = userCredential.User;
            // migrage seed
            string token = await this.GetIdToken().ConfigureAwait(false);
            await jimmyClient.Migrage(token, User.Uid).ConfigureAwait(false);
        }
        else
        {
            var credential = await fbClient.CreateUserWithEmailAndPasswordAsync(email, password);
            User = credential.User;
            string token = await this.GetIdToken().ConfigureAwait(false);
            var seed = await jimmyClient.CreateSeed(token);
            this.SignUpSignature = seed.Sign;
            var user = FinalBiome.Api.Tx.Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
            seed.SeedData);
            this.Account = user;
        }
        await NotifyStateChanges(this.UserInfo is not null).ConfigureAwait(false);

        if (StateChanged is not null)
        {
            Console.WriteLine($"Invoke StateChanged (SignUp): {this.UserInfo is not null}");
            await StateChanged(this.UserInfo is not null).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Sign in anonymously.
    /// </summary>
    /// <returns></returns>
    public async Task SignInAsAnonym()
    {
        InitFirebaseAuthClient();

        await fbClient.SignInAnonymouslyAsync().ConfigureAwait(false);
        await FetchSeedAsAnonymous().ConfigureAwait(false);
    }

    public async Task SignOut()
    {
        InitFirebaseAuthClient();

        await fbClient.SignOutAsync().ConfigureAwait(false);

        await NotifyStateChanges(false).ConfigureAwait(false);

        if (StateChanged is not null)
        {
            await StateChanged(false).ConfigureAwait(false);
        }

        Account = null;
        UserInfo = null;
        _signer = null;
        _gamerAccount = null;
    }

    /// <summary>
    /// Fetch seed from Jimmy by Firebase user and set it in the AuthClient
    /// </summary>
    /// <param name="fbUser"></param>
    /// <returns></returns>
    private async Task FetchSeedByFbAuth()
    {
        if (this.UserInfo is not null)
        {
            // get token
            string token = await this.GetIdToken().ConfigureAwait(false);
            // get a seed from the jimmy, if it doesn't exist, create it.
            // TODO: Refactor this. see must be creates when registers new account in the firebase. Or not?
            Seed seed;
            try
            {
                seed = await jimmyClient.GetSeed(token).ConfigureAwait(false);
            }
            catch (Jimmy.JimmyException e)
            {
                if (e.Reason == Jimmy.JimmyErrorReason.NotFound)
                {
                    // it means the seed was not created before
                    // so, create it
                    seed = await jimmyClient.CreateSeed(token).ConfigureAwait(false);
                    this.SignUpSignature = seed.Sign;
                }
                else
                {
                    throw;
                }
            }
            var user = FinalBiome.Api.Tx.Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                seed.SeedData);
            this.Account = user;
        }

        await NotifyStateChanges(this.UserInfo is not null).ConfigureAwait(false);

        if (StateChanged is not null)
            await StateChanged(this.UserInfo is not null).ConfigureAwait(false);
    }

    private async Task FetchSeedAsAnonymous()
    {
        if (User is null) throw new Exception("Can't get anonymous seed, SignInAsAnonym first.");
        if (!User.IsAnonymous) throw new Exception("Can't get anonymous seed, user is not anonym");

        Seed seed = await jimmyClient.AnonimousSeed(User.Uid).ConfigureAwait(false);
        this.SignUpSignature = seed.Sign;
        var user = FinalBiome.Api.Tx.Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
            seed.SeedData);
        this.Account = user;

        await NotifyStateChanges(this.UserInfo is not null).ConfigureAwait(false);

        if (StateChanged is not null)
            await StateChanged(this.UserInfo is not null).ConfigureAwait(false);
    }

    private void FbAuthStateHandler(object? o, UserEventArgs e)
    {
        // we need this handler, because if it not exists, firebase client doesn't read existed user from the local storage.
        this.User = e.User;
    }

    // this is a crutch for cases when the firebase client did not have time to initialize the saved user credentials
    private async Task<bool> GetUserInfo()
    {
        var (userInfo, _) = await this.fbConfig.UserManager.GetUserAsync();
        this.UserInfo = userInfo;
        return this.UserInfo is not null;
    }

    private async Task<string> GetIdToken(bool forceRefresh = false)
    {
        if (User is not null) return await User.GetIdTokenAsync().ConfigureAwait(false);

        // Console.WriteLine($"GetIdToken (User null)");
        // if user not exists, try make handmade token
        var (userInfo, credential) = await this.fbConfig.UserManager.GetUserAsync();
        if (userInfo is null || credential is null) throw new Exception("User not logged in");

        this.UserInfo = userInfo;

        if (forceRefresh || credential.IsExpired())
        {
            var token = new RefreshToken(this.fbConfig);
            var refresh = await token.ExecuteAsync(new RefreshTokenRequest
            {
                GrantType = "refresh_token",
                RefreshToken = credential.RefreshToken
            });

            credential = new FirebaseCredential
            {
                ExpiresIn = refresh.ExpiresIn,
                IdToken = refresh.IdToken,
                ProviderType = credential.ProviderType,
                RefreshToken = refresh.RefreshToken
            };
        }

        return credential.IdToken;
    }
}
