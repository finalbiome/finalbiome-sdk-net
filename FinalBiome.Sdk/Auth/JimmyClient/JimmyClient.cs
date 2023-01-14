
namespace FinalBiome.Sdk.Jimmy;

internal class JimmyClient
{
    readonly AnonymousSeed anonymousSeed;
    readonly CreateSeed createSeed;
    readonly GetSeed getSeed;
    readonly Migrate migrate;
    readonly Remove remove;

    internal JimmyClient()
    {
        this.anonymousSeed = new();
        this.createSeed = new();
        this.getSeed = new();
        this.migrate = new();
        this.remove = new();
    }

    /// <summary>
    /// Get a seed for auth by credentials
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    internal async Task<Seed> GetSeed(string token)
    {
        var response = await this.getSeed.ExecuteAsync(new object(), token).ConfigureAwait(false);
        return new(response);
    }

    /// <summary>
    /// Creaing and returns a generated seed
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    internal async Task<Seed> CreateSeed(string token)
    {
        var response = await this.createSeed.ExecuteAsync(new object(), token).ConfigureAwait(false);
        return new(response);
    }
    /// <summary>
    /// If deviceId is new, a new seed is generated,
    /// otherwise an already generated phrase is returned.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    internal async Task<Seed> AnonimousSeed(string deviceId)
    {
        var response = await this.anonymousSeed.ExecuteAsync(new object(), null, deviceId).ConfigureAwait(false);
        return new(response);
    }

    /// <summary>
    /// Moves the account to the general authentication level for more security.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="deviceId"></param>
    /// <returns></returns>
    internal async Task Migrage(string token, string deviceId)
    {
        var _ = await this.migrate.ExecuteAsync(new DeviceIdRequest { DeviceId = deviceId }, token, deviceId).ConfigureAwait(false);
        return;
    }

    /// <summary>
    ///  Revokes credentials. The user manages the authentication credentials on their own.
    /// </summary>
    /// <param name="token"></param>
    /// <param name="deviceId"></param>
    /// <returns></returns>
    internal async Task Remove(string token, string deviceId)
    {
        var _ = await this.remove.ExecuteAsync(new DeviceIdRequest { DeviceId = deviceId }, token, deviceId).ConfigureAwait(false);
        return;
    }
}

internal class Seed
{
    public readonly byte[] SeedData;

    /// <summary>
    /// Raw signature, if returned from Jimmy
    /// </summary>
    public readonly byte[]? Sign;

    internal Seed(PhraseResponse phraseResponse)
    {
        this.SeedData = FinalBiome.Api.Utils.HexUtils.HexToBytes(phraseResponse.Seed);
        this.Sign = phraseResponse.Sign is null ? null : FinalBiome.Api.Utils.HexUtils.HexToBytes(phraseResponse.Sign);
    }
}
