namespace FinalBiome.Api.Test;
using Types.Primitive;

public class I8Tests
{
    [Test]
    public void U8Test()
    {
        var val = new I8();
        val.Init("0xf5");
        Assert.That(val.Value, Is.EqualTo(-11));
    }
}


