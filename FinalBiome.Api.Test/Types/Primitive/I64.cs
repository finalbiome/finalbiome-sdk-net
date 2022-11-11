namespace FinalBiome.Api.Test;

using FinalBiome.Api.Utils;
using Types.Primitive;

public class I64Tests
{
    [Test]
    public void I64FromHexTest()
    {
        var val = new I64();
        val.Init("0xf5f5f5f5f5f5f5f5");
        Assert.That(val.Value, Is.EqualTo(-723401728380766731));
    }
}


