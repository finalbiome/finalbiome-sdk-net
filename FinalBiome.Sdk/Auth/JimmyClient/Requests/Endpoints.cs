

namespace FinalBiome.Sdk.Jimmy;

internal static class Endpoints
{
    const string API_AUTH_ENDPOINT = "https://fq7urbuui6.execute-api.eu-west-1.amazonaws.com/prod";
    /// <summary>
    /// Get phrase for anonimous auth
    /// </summary>
    /// <value></value>
    public const string AnonimousSeed = API_AUTH_ENDPOINT + "/auth/anonymous/{0}";
    /// <summary>
    /// Create a new phrase for auth
    /// </summary>
    public const string CreateSeed = API_AUTH_ENDPOINT + "/auth/general/new";
    /// <summary>
    /// Get a phrase for auth by credentials
    /// </summary>
    public const string GetSeed = API_AUTH_ENDPOINT + "/auth/general/get";
    /// <summary>
    /// Migrate acc to the General auth level
    /// </summary>
    public const string Migrate = API_AUTH_ENDPOINT + "/auth/general/migrate";
    /// <summary>
    /// Revoke acc credentials
    /// </summary>
    public const string Remove = API_AUTH_ENDPOINT + "/auth/full/remove";
}
