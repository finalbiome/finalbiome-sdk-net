namespace FinalBiome.Sdk;

public class NetworkException : Exception
{
    public NetworkException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
