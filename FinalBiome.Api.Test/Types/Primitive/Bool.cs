namespace FinalBiome.Api.Test;
using Types.Primitive;

public class BoolTests
{
    [Test]
    public void BoolTrue()
    {
        var val = new Bool();
        val.Init("0x00");
        Assert.That(val.Value, Is.EqualTo(false));
    }

    [Test]
    public void BoolFalse()
    {
        var val = new Bool();
        val.Init("0x01");
        Assert.That(val.Value, Is.EqualTo(true));
    }
}


