
namespace FinalBiome.Sdk.Jimmy;

/// <summary>
/// Rovokes credentials. The user manages the authentication credentials on their own.
/// </summary>
public class Remove : JimmyRequestBase<DeviceIdRequest, object>
{
    public Remove() : base()
    {
    }

    protected override string UrlFormat => Endpoints.Remove;
    protected override HttpMethod Method => HttpMethod.Post;
}
