
namespace FinalBiome.Sdk.Jimmy;

/// <summary>
/// Moves the account to the general authentication level for more security.
/// </summary>
public class Migrate : JimmyRequestBase<DeviceIdRequest, object>
{
    public Migrate() : base()
    {
    }

    protected override string UrlFormat => Endpoints.Migrate;
    protected override HttpMethod Method => HttpMethod.Post;
}
