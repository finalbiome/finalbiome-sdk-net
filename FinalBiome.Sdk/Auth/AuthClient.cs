using FinalBiome.Api.Tx;

namespace FinalBiome.Sdk;

public class AuthClient
{
    readonly Client client;
    Api.Tx.Account? _user;
    /// <summary>
    /// Current FinalBiome user.
    /// </summary>
    internal Api.Tx.Account? user
    {
        get => _user;
        set {
            _user = value;
            signer = value is null ? null : new PairSigner(value);
        }
    }

    /// <summary>
    /// The user address in the network.
    /// </summary>
    public Api.Types.SpCore.Crypto.AccountId32? UserAddress
    {
        get
        {
            if (user is null) return null;
            return user;
        }
    }

    internal PairSigner? signer;

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


    public AuthClient(Client client)
    {
        this.client = client;
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

        // as long as it's just a stub
        // set user as Dave
        var user = FinalBiome.Api.Tx.Account.FromSeed(FinalBiome.Api.Types.SpRuntime.InnerMultiSignature.Sr25519,
            FinalBiome.Api.Utils.HexUtils.HexToBytes("0x868020ae0687dda7d57565093a69090211449845a7e11453612800b663307246"));
        this.user = user;

        if (StateChanged is not null)
            await StateChanged(true);
    }

    public async Task SignOut()
    {
        user = null;
        if (StateChanged is not null)
            await StateChanged(false);
    }
}
