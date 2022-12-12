using FinalBiome.Api.Types.SpCore.Crypto;
using FinalBiome.Api.Utils;

namespace FinalBiome.Sdk;

/// <summary>
/// A config of Sdk that can be used to initialize the client.
/// </summary>
public class ClientConfig
{
    /// <summary>
    /// The game SS58 Address. Like `5FHneW46xGXgs5mUiveU4sbTyGBzmstUspZC92UhjJM694ty`
    /// </summary>
    public string Game { get; set; }
    public AccountId32 GameAccount { get; internal set; }
    /// <summary>
    /// The Uri for connecting to the FinalBiome network. Like `wss://rpc.finalbiome.net`
    /// Default `ws://127.0.0.1:9944`
    /// Required
    /// </summary>
    public string Endpoint { get; set; }
    /// <summary>
    /// Create new confuguration for the App
    /// </summary>
    /// <param name="game">The game SS58 Address</param>
    /// <param name="endpoint">The endpoint for connection to the FinalBiome network</param>
#pragma warning disable CS8618
    public ClientConfig(string game, string? endpoint = null)
#pragma warning restore CS8618

    {
        Game = game;
        AccountId32 accountId32 = new();
        accountId32.Init(AddressUtils.GetPublicKeyFrom(game));
        GameAccount = accountId32;
        Endpoint = endpoint is null ? "ws://127.0.0.1:9944" : endpoint;
    }
}

