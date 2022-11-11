namespace FinalBiome.Api.Test;

using System.Numerics;
using FinalBiome.Api.Utils;
using Types.Primitive;

public class U128Tests
{
    [Test]
    public void U128FromHexTest()
    {
        var val = new U128();
        val.Init("0xffffff00ffffff00ffffff00ffffff00");
        Assert.That(BigInteger.Parse("1329227916866238350086128051511361535"), Is.EqualTo(val.Value));
    }

    [Test]
    public void U128FromNative()
    {
        var val = U128.From(new BigInteger(33333));
        Assert.That(HexUtils.Bytes2HexString(val.Bytes), Is.EqualTo("0x35820000000000000000000000000000"));

        var val2 = new U128();
        val2.Init("0x35820000000000000000000000000000");
        U128.From(new BigInteger(33333));

        Assert.That(new BigInteger(33333), Is.EqualTo(val2.Value));
        Assert.That(val.Bytes, Is.EqualTo(val2.Bytes));

    }
}


