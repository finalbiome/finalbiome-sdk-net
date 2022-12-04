namespace FinalBiome.Sdk;

/// <summary>
/// A FinalBiome App is a container-like object that stores common configuration and shares authentication across FinalBiome services.
/// After you initialize a Firebase App object in your code, you can start using FinalBiome services.
/// </summary>
public class Client : IDisposable
{
    public readonly ClientConfig config;

    /// <summary>
    /// The lowlevel api client for comunication with network
    /// </summary>
    public readonly Api.Client api;

    public GameClient Game { get; internal set; }
    public FaClient Fa { get; internal set; }
    public NfaClient Nfa { get; internal set; }
    public AuthClient Auth { get; internal set; }

    Client(ClientConfig config, Api.Client api)
    {
        this.config = config;
        this.api = api;
    }

    public static async Task<Client> Create(ClientConfig config)
    {

        Api.Client api = await Api.Client.FromUrl(config.Endpoint);
        Client client = new(config, api);
        
        AuthClient auth = new(client);
        client.Auth = auth;
        // subscribe to the user state changes
        client.Auth.StateChanged += client.HandleUserStateChangedEvent;
        // game client we must be init before other modules
        var gameClient = await GameClient.Create(client);
        client.Game = gameClient;

        var faClientTask = FaClient.Create(client);
        var NfaClientTask = NfaClient.Create(client);

        await Task.WhenAll(faClientTask, NfaClientTask);

        var faClient = await faClientTask;
        var nfaClient = await NfaClientTask;

        client.Fa = faClient;
        client.Nfa = nfaClient;

        return client;
    }

    /// <summary>
    /// If user status has been changed, we need fetch user data from the network or clean existed data.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    async Task HandleUserStateChangedEvent(bool logedIn)
    {
        if (logedIn)
        {
            // user sign in
            // here we need fetch and subscribe to Game state
            // here we need fetch and subscribe to FA state
            // await Fa.StartSubscriber();
            // here we need fetch and subscribe to NFA state
        }
        else
        {
            // user sign out
            // here we need clean and unsubscribe from Game state
            // here we need clean and unsubscribe from FA state
            // await Fa.StopSubscriber();
            // here we need clean and unsubscribe from NFA state

        }
    }

    public void Dispose()
    {
        Fa?.Dispose();
        Nfa?.Dispose();
        GC.SuppressFinalize(this);
    }
}
