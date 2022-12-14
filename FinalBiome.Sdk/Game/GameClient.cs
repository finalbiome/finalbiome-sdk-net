using FinalBiome.Api.Types.PalletOrganizationIdentity.Types;
using FinalBiome.Api.Types.SpCore.Crypto;
using FinalBiome.Api.Utils;

namespace FinalBiome.Sdk;

/// <summary>
/// A Game client which holds information about the game, fetched from network
/// </summary>
public class GameClient
{
    /// <summary>
    /// An address of the game in the network.
    /// </summary>
    /// <value></value>
    public AccountId32 Address { get; internal set; }
    public GameData Data { get; internal set; }

    readonly Client client;
#pragma warning disable CS8618
    GameClient(Client client)
#pragma warning restore CS8618
    {
        this.client = client;
        this.Address = this.client.config.GameAccount;
    }

    public static async Task<GameClient> Create(Client client) {
        GameClient gameClient = new (client);
        gameClient.Data = await gameClient.GetGameData().ConfigureAwait(false);
        return gameClient;
    }

    /// <summary>
    /// Get Game data from the network
    /// </summary>
    /// <returns></returns>
    private async Task<GameData> GetGameData()
    {
        OrganizationDetails? details = await client.api.Storage.OrganizationIdentity.Organizations(this.Address).Fetch().ConfigureAwait(false);

        if (details is null) throw new GameNotFoundException(this.client.config.Game);
        
        GameData gd = new(VecU8Utils.ToString(details.Name));

        return gd;
    }
}
