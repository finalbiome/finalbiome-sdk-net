using FinalBiome.Api.Tx;
using Firebase.Auth;
using Firebase.Auth.Providers;

namespace FinalBiome.Sdk;

using GamerAccount = Api.Types.PalletSupport.GamerAccount;

public class AuthClient
{
    readonly Client client;

    readonly Jimmy.JimmyClient jimmyClient;

    /// <summary>
    /// Current FinalBiome user.
    /// </summary>
    internal Api.Tx.Account? user { get; set; }

    /// <summary>
    /// The user address in the network.
    /// Throw error ErrorNotAuthenticatedException if user not set.
    /// </summary>
    /// <value></value>
    public Api.Types.SpCore.Crypto.AccountId32 UserAddress
    {
        get
        {
            if (user is null) throw new ErrorNotAuthenticatedException();
            return user;
        }
    }

    PairSigner? _signer;
    internal PairSigner signer
    {
        get
        {
            if (user is null) throw new ErrorNotAuthenticatedException();
            _signer ??= new PairSigner(user);
            return _signer;
        }
    }

    GamerAccount? _gamerAccount;
    internal GamerAccount GamerAccount
    {
        get
        {
            if (user is null) throw new ErrorNotAuthenticatedException();
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
    /// Indicates whether a user account is set or not <br/>
    /// This can be interpreted as whether the user is logged in or not.
    /// </summary>
    public bool UserIsSet => user is not null;

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

    readonly FirebaseAuthClient fbClient;

    public AuthClient(Client client)
    {
        this.client = client;
        this.jimmyClient = new();
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

        this.fbClient = new(config);
        this.fbClient.AuthStateChanged += FbAuthStateHandler;
    }

    /// <summary>
    /// Sing in user with email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task SignInWithEmailAndPassword(string email, string password)
    {
        try
        {
            UserCredential _ = await fbClient.SignInWithEmailAndPasswordAsync(email, password).ConfigureAwait(false);
        }
        catch (FirebaseAuthException e)
        {
            throw e;
        }
        await FetchSeedByFbAuth().ConfigureAwait(false);
    }

    public async Task SignOut()
    {
        await fbClient.SignOutAsync().ConfigureAwait(false);
        user = null;
        if (StateChanged is not null)
            await StateChanged(false).ConfigureAwait(false);
    }

    /// <summary>
    /// Fetch seed from Jimmy by Firebase user and set it in the AuthClient
    /// </summary>
    /// <param name="fbUser"></param>
    /// <returns></returns>
    internal async Task FetchSeedByFbAuth()
    {
        if (this.fbClient.User is not null)
        {
            // get token
            string token = await this.fbClient.User.GetIdTokenAsync().ConfigureAwait(false);
            // get a seed from the jimmy, if it doesn't exist, create it.
            // TODO: Refactor this. see must be creates when registers new account in the firebase. Or not?
            string seed;
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

                }
                else
                {
                    throw;
                }
            }
            var user = FinalBiome.Api.Tx.Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
                FinalBiome.Api.Utils.HexUtils.HexToBytes(seed));
            this.user = user;
        }

        if (StateChanged is not null)
            await StateChanged(this.fbClient.User is not null).ConfigureAwait(false);
    }

    public void FbAuthStateHandler(object? o, UserEventArgs e)
    {
        // we need this handler, because if it not exists, firebase client doesn't read existed user from the local storage.
    }
}
