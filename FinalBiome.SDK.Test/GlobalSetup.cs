using System.Diagnostics;
using FinalBiome.Api.Types.FrameSystem.Pallet;

namespace FinalBiome.Sdk.Test;

[SetUpFixture]
public class GlobalSetup
{
    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        // set onboarding for Eve game
        await NetworkHelpers.SetGameOnboardingData();
        // do unboarding for default test gamer.

        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await FinalBiome.Sdk.Client.Create(config);

        await client.Auth.SignInWithEmailAndPassword("testdave@finalbiome.net", "testDave@finalbiome.net");
        // check balance for the gamer for the ability to make game transactions
        await NetworkHelpers.TopupAccountBalance(client.Auth.user!.ToAddress());

        try {
            await client.Mx.OnboardToGame();
        }
        catch (FinalBiome.Api.Tx.Errors.ExtrinsicFailedException e)
        {
            if (e.IsModule && e.ModuleName == "OrganizationIdentity" && e.ModuleError == "AlreadyOnboarded")
            {
                // ignore that
            }
            else
            {
                throw;
            }
        }

    }
}
