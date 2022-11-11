namespace FinalBiome.Api.Test;

using FinalBiome.Api.Utils;
using Types.Primitive;

public class U64Tests
{
    [Test]
    public void U64FromHexTest()
    {
        var val = new U64();
        val.Init("0xffffff00ffffff00");
        Assert.That(val.Value, Is.EqualTo(72057589759737855));
    }

    [Test]
    public void U64FromNative()
    {
        var val = U64.From(33333);
        Assert.That(HexUtils.Bytes2HexString(val.Bytes), Is.EqualTo("0x3582000000000000"));
    }
}


