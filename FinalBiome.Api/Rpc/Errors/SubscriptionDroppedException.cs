namespace FinalBiome.Api.Rpc;

public class SubscriptionDroppedException : Exception
{
    public SubscriptionDroppedException() : base(MessageFactory())
    {
    }

    static string MessageFactory()
    {
        return $"The RPC subscription dropped.";
    }
}

