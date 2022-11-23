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

    [Test]
    public void BoolImplicit()
    {
        var val = new Bool();
        val.Init(true);
        bool b = val;
        Assert.That(b, Is.EqualTo(true));
    }

    [Test]
    public void BoolExplicit()
    {
        Bool val = (Bool)false;
        Assert.That(val.Value, Is.EqualTo(false));
    }
}


