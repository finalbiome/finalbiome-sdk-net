
namespace FinalBiome.Sdk.Jimmy;

/// <summary>
/// Creaing and returns a generated phrase.
/// </summary>
public class CreateSeed : JimmyRequestBase<object, PhraseResponse>
{
    public CreateSeed() : base()
    {
    }

    protected override string UrlFormat => Endpoints.CreateSeed;
}
