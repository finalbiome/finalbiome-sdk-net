namespace FinalBiome.Sdk;

public class AuthClient
{
    readonly Client client;
    FinalBiome.Api.Tx.Account? _user;
    /// <summary>
    /// Current FinalBiome user.
    /// </summary>
    Api.Tx.Account? user
    {
        get => _user;
        set
        {
            _user = value;
            // if user has bee changed, raise the error
            OnStateChangedEvent();
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

    /// <summary>
    /// Indicates whether a user account is set or not <br/>
    /// This can be interpreted as whether the user is logged in or not.
    /// </summary>
    public bool UserIsSet => user is not null;

    /// <summary>
    /// This event gets called whenever the user's account changes.
    /// </summary>
    public event EventHandler? StateChangedEvent;

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
    }

    public async Task SignOut()
    {
        this.user = null;
    }

    void OnStateChangedEvent()
    {
        StateChangedEvent?.Invoke(this, EventArgs.Empty);
    }
}
