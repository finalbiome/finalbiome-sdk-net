
namespace FinalBiome.Sdk.Jimmy;

/// <summary>
/// Moves the account to the general authentication level for more security.
/// </summary>
public class GetSeed : JimmyRequestBase<object, PhraseResponse>
{
    public GetSeed() : base()
    {
    }

    protected override string UrlFormat => Endpoints.GetSeed;
}
