
namespace FinalBiome.Sdk.Jimmy;

/// <summary>
/// If deviceId is new, a new phrase is generated,
/// otherwise an already generated phrase is returned.
/// </summary>
public class AnonymousSeed : JimmyRequestBase<object, PhraseResponse>
{
    public AnonymousSeed() : base()
    {
    }

    protected override string UrlFormat => Endpoints.AnonimousSeed;
}
