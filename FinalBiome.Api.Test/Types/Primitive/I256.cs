namespace FinalBiome.Api.Test;

using System.Numerics;
using FinalBiome.Api.Utils;
using Types.Primitive;

public class U256Tests
{
    [Test]
    public void U256FromHexTest()
    {
        var val = new U256();
        val.InitFromHex("0xffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00");
        Assert.That(BigInteger.Parse("452325621728632006638659744032470891714787547825123743022878680681856106495"), Is.EqualTo(val.Value));
    }

    [Test]
    public void U256FromNative()
    {
        var val = U256.From(BigInteger.Parse("452325621728632006638659744032470891714787547825123743022878680681856106495"));
        Assert.That(HexUtils.Bytes2HexString(val.Bytes), Is.EqualTo("0xffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00"));
    }
}


