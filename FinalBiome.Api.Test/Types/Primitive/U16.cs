namespace FinalBiome.Api.Test;

using FinalBiome.Api.Utils;
using Types.Primitive;

public class U32Tests
{
    [Test]
    public void U32FromHexTest()
    {
        var val = new U32();
        val.Init("0xffffff00");
        Assert.That(val.Value, Is.EqualTo(16777215));
    }

    [Test]
    public void U32FromNative()
    {
        var val = U32.From(33333);
        Assert.That(HexUtils.Bytes2HexString(val.Bytes), Is.EqualTo("0x35820000"));
    }
}


