namespace FinalBiome.Sdk;

/// <summary>
/// User is unauthenticated. Authenticate and try again.
/// </summary>
public class ErrorNotAuthenticatedException : Exception
{
    public ErrorNotAuthenticatedException() : base("User is unauthenticated. Authenticate and try again.")
    {

    }
}
