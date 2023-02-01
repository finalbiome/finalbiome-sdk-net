using System.Diagnostics;
using FinalBiome.Api.Types.FrameSystem.Pallet;

namespace FinalBiome.Sdk.Test;

[SetUpFixture]
public class GlobalSetup
{
    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame)
        {
            // set persistence path for storing data
            PersistenceDataPath = Path.GetTempPath(),
        };
        using Client client = await FinalBiome.Sdk.Client.Create(config);

        if (!await client.Auth.IsLoggedIn())
        {
            await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
            // check balance for the gamer for the ability to make game transactions

            if (!(bool)client.Game.IsOnboarded!)
            {
                await NetworkHelpers.TopupAccountBalance(client.Auth.Account!.ToAddress());
                await client.Mx.OnboardToGame();
            }
        }
    }

    [OneTimeSetUp]
    public void DotEnvLoader()
    {
        // This will get the current WORKING directory (i.e. \bin\Debug)
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;

        string envFilePath = Path.Combine(projectDirectory, ".env");

        if (!File.Exists(envFilePath)) return;

        foreach (var line in File.ReadAllLines(envFilePath))
        {
            var parts = line.Split(
                '=',
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                continue;

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }

    }
}
