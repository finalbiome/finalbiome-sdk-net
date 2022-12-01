using FinalBiome.Api.Extensions;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Types.PalletSupport;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId;

namespace FinalBiome.Sdk.Test;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
public class NfaClientTests
{
    [Test]
    public async Task GetClassDetailsTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var classId = 1u;
        var details = await client.GetClassDetails(classId);
        Assert.That(details, Is.Not.Null);
        Assert.That(details.Name.ToHuman(), Is.EqualTo("\"Stave\""));
    }

    [Test]
    public async Task GetClassDetailsNotFoundTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var classId = 9999u;
        Assert.ThrowsAsync<NfaClassNotFoundException>(() => client.GetClassDetails(classId));
    }

    [Test]
    /// <summary>
    /// For this test Dave must owned instance 0 of nfa 1
    /// </summary>
    /// <returns></returns>
    public async Task GetInstanceDetailsTest()
    {
        // by new nfa
        (NfaClassId classId, NfaInstanceId instanceId) = await NetworkHelpers.ExecBuyNfaMechanic();
        
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var details = await client.GetInstanceDetails(classId, instanceId);
        Assert.Multiple(() =>
        {
            Assert.That(details, Is.Not.Null);
            Assert.That(details.Owner.ToHuman(), Is.EqualTo("\"5DAAnrj7VHTznn2AWBemMuyBwZWs6FNFjdyVXUeYum3PTXFy\""));
            Assert.That(details.Locked.Value, Is.EqualTo(InnerLocker.None));
        });
    }

    [Test]
    public async Task GetInstanceDetailsNotFoundTest()
    {
        string eveGame = "5HGjWAeFDfFCWPsjFQdVV2Msvz2XtMktvgocEZcCj68kUMaw";
        ClientConfig config = new(eveGame);
        var cl = await Client.Create(config);

        NfaClient client = new(cl);

        var classId = 9999u;
        var instanceId = 9999u;
        Assert.ThrowsAsync<NfaInstanceNotFoundException>(() => client.GetInstanceDetails(classId, instanceId));
    }
}
