namespace FinalBiome.Sdk;

public class GameNotFoundException : Exception
{
    public GameNotFoundException(string gameSS58Address) : base(MessageFactory(gameSS58Address))
    {

    }

    static string MessageFactory(string gameSS58Address)
    {
        return $"Address {gameSS58Address} is not a game";
    }
}
