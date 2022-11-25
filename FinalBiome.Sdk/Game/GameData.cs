namespace FinalBiome.Sdk;

/// <summary>
/// The data of the game fetched from the network
/// </summary>
public class GameData
{
    public string Name{ get; internal set; }

    public GameData(string name)
    {
      Name = name;
    }
}
