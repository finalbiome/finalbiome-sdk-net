using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Test;

public class CompactTests
{
    [Test]
    public void CompactU32Test()
    {
        var val = new U32();
        val.Init("0xffffff00");

        var c = new CompactU32();
        c.Init(val);

        Assert.That(c.Value, Is.EqualTo(val));

        var d = new CompactU32();
        d.Decode(c.Encode());

        Assert.That(c.Value.Value, Is.EqualTo(d.Value.Value));
        Assert.That(c.Value.Value, Is.EqualTo(16777215));


    }
}

