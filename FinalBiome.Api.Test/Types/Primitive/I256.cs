namespace FinalBiome.Api.Test;

using System.Numerics;
using FinalBiome.Api.Utils;
using Types.Primitive;

public class I256Tests
{
    [Test]
    public void I256FromHexTest()
    {
        var val = new I256();
        val.Init("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
        Assert.That(BigInteger.Parse("-4540866244600635114649842549360310111892940575123159374096375843447573711371"), Is.EqualTo(val.Value));
    }
}


