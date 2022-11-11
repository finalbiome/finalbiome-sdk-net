namespace FinalBiome.Api.Test;

using System.Numerics;
using FinalBiome.Api.Utils;
using Types.Primitive;

public class I128Tests
{
    [Test]
    public void I128FromHexTest()
    {
        var val = new I128();
        val.Init("0xf5f5f5f5f5f5f5f5f5f5f5f5f5f5f5f5");
        Assert.That(BigInteger.Parse("-13344406545919155429936259114971302411"), Is.EqualTo(val.Value));
    }
}


