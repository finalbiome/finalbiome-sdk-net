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
        this.fbClient = new(config);
    }

    /// <summary>
    /// Sing in user with email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task SignInWithEmailAndPassword(string email, string password)
    {
        // TODO: implement it
        User? fbUser;
        try
        {
            UserCredential userCredential = await fbClient.SignInWithEmailAndPasswordAsync(email, password).ConfigureAwait(false);
            fbUser = userCredential.User;
        }
        catch (FirebaseAuthException e)
        {
            throw e;
        }
        // get token
        string token = await fbUser.GetIdTokenAsync().ConfigureAwait(false);
        // get a seed from the jimmy
        string seed = await jimmyClient.GetSeed(token).ConfigureAwait(false);

        var user = FinalBiome.Api.Tx.Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
            FinalBiome.Api.Utils.HexUtils.HexToBytes(seed));
        this.user = user;

        if (StateChanged is not null)
            await StateChanged(true).ConfigureAwait(false);
    }

    public async Task SignOut()
    {
        await fbClient.SignOutAsync().ConfigureAwait(false);
        user = null;
        if (StateChanged is not null)
            await StateChanged(false).ConfigureAwait(false);
    }
}
