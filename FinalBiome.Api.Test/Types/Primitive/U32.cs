namespace FinalBiome.Api.Test;

using FinalBiome.Api.Utils;
using Types.Primitive;

public class U16Tests
{
    [Test]
    public void U16FromHexTest()
    {
        var val = new U16();
        val.Init("0x2a00");
        Assert.That(val.Value, Is.EqualTo(42));
    }

    [Test]
    public void U16FromNative()
    {
        var val = U16.From(33333);
        Assert.That(HexUtils.Bytes2HexString(val.Bytes), Is.EqualTo("0x3582"));
    }
}


