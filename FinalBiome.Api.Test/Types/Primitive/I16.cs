namespace FinalBiome.Api.Test;

using FinalBiome.Api.Utils;
using Types.Primitive;

public class I16Tests
{
    [Test]
    public void U32FromHexTest()
    {
        var val = new I16();
        val.Init("0xf5f5");
        Assert.That(val.Value, Is.EqualTo(-2571));
    }
}


