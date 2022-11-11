namespace FinalBiome.Api.Test;
using Types.Primitive;

public class U8Tests
{
    [Test]
    public void U8Test()
    {
        var val = new U8();
        val.InitFromHex("0x45");
        Assert.That(val.Value, Is.EqualTo(69));
    }
}


