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
        val.Init("0xffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00");
        var b = BigInteger.Parse("452312821728632006638659744032470891714787547825123743022878680681856106495");
        //var b1 = BigInteger.Parse("452325621728632006638659744032470891714787547825123743022878680681856106495");
        //var val2 = new U256();
        //val2.Init(b1);
        //Assert.That(b1, Is.EqualTo(val2.Value));
        Assert.That(BigInteger.Parse("452312821728632006638659744032470891714787547825123743022878680681856106495"), Is.EqualTo(val.Value));
    }

    [Test]
    public void U256FromNative()
    {
        var val = U256.From(BigInteger.Parse("452312821728632006638659744032470891714787547825123743022878680681856106495"));
        Assert.That(HexUtils.Bytes2HexString(val.Bytes).ToLower(), Is.EqualTo("0xffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00ffffff00"));
    }
}


