namespace FinalBiome.Api.Test;

using FinalBiome.Api.Utils;
using Types.Primitive;

public class I32Tests
{
    [Test]
    public void I32FromHexTest()
    {
        var val = new I32();
        val.Init("0xf5f5f5f5");
        Assert.That(val.Value, Is.EqualTo(-168430091));
    }
}


