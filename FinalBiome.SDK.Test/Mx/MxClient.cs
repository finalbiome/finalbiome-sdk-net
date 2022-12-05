namespace FinalBiome.Sdk.Test;

public class MxClientTests
{
    [Test]
    public async Task HasNonceAfterLoginTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);

        Assert.That(client.Mx.accountNonce, Is.Null);

        await client.Auth.SignInWithEmailAndPassword("dave", "pass");
        
        Assert.That(client.Mx.accountNonce, Is.Not.Null);
    }

    [Test]
    public async Task SuccessExecBuyNfaTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);
        await client.Auth.SignInWithEmailAndPassword("dave", "pass");
        
        var res = await client.Mx.ExecBuyNfa(0, 0);

        Assert.That(res.Status, expression: Is.EqualTo(ResultStatus.Finished));
    }

    [Test]
    public async Task FailedExecBuyNfaTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        using Client client = await Client.Create(config);
        await client.Auth.SignInWithEmailAndPassword("dave", "pass");
        
        try {
            var res = await client.Mx.ExecBuyNfa(0, 999);
            Assert.That(res.Status, expression: Is.EqualTo(ResultStatus.Finished));

        } catch (Exception e) {
            
        }

    }
    
}
