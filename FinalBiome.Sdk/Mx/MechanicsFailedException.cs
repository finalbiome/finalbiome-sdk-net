
namespace FinalBiome.Sdk;

public class MechanicsFailedException : Exception
{
    public MechanicsFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
