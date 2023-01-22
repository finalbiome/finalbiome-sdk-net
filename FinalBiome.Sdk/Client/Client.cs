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

    internal readonly NetworkEventsListener networkEventsListener;

    public GameClient Game { get; internal set; }
    public FaClient Fa { get; internal set; }
    public NfaClient Nfa { get; internal set; }
    public AuthClient Auth { get; internal set; }
    public MxClient Mx { get; internal set; }


#pragma warning disable CS8618
    Client(ClientConfig config, Api.Client api)
#pragma warning restore CS8618
    {
        this.config = config;
        this.api = api;
        this.networkEventsListener = new(this);

        // this.config.InternalStateChanged += HandleUserStateChangedEvent;
    }

    public static async Task<Client> Create(ClientConfig config)
    {

        Api.Client api = await Api.Client.FromUrl(config.Endpoint).ConfigureAwait(false);
        Client client = new(config, api);
        
        // the game client we must init before other modules
        var gameClient = await GameClient.Create(client).ConfigureAwait(false);
        client.Game = gameClient;

        var faClientTask = FaClient.Create(client);
        var NfaClientTask = NfaClient.Create(client);
        var MxClientTask = MxClient.Create(client);

        await Task.WhenAll(faClientTask, NfaClientTask, MxClientTask).ConfigureAwait(false);

        var faClient = await faClientTask.ConfigureAwait(false);
        var nfaClient = await NfaClientTask.ConfigureAwait(false);
        var mxClient = await MxClientTask.ConfigureAwait(false);
        
        client.Fa = faClient;
        client.Nfa = nfaClient;
        client.Mx = mxClient;

        client.InitAuthClient();
        
        return client;
    }

    void InitAuthClient()
    {
        Console.WriteLine($"InitAuthClient");
        
        Auth = new AuthClient(this);
        // subscribe to the state changes for internal clients
        if (config.InternalStateChanged is not null)
        {
            Auth.StateChanged += config.InternalStateChanged; //.Clone() as FinalBiome.Sdk.AuthClient.OnStateChanged;
        }

        config.InternalStateChanged = null;
    }

    public void Dispose()
    {
        networkEventsListener.Dispose();
        Fa?.Dispose();
        Nfa?.Dispose();
        Mx?.Dispose();
        api.Dispose();
        GC.SuppressFinalize(this);
    }
}
