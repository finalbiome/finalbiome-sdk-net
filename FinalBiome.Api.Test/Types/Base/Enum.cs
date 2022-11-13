using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using Newtonsoft.Json.Linq;

namespace FinalBiome.Api.Test;

public class EnumTests
{
    public enum A { A, B, C}

    [Test]
    public void EnumWithNoData()
    {
        var e1 = new Enum<A>();
        var e2 = new Enum<A>();
        var e3 = new Enum<A>();

        e1.Init("0x00");
        e2.Init(A.A, new Types.Void());
        e3.Decode(e2.Encode());

        Assert.Multiple(() =>
        {
            Assert.That(e1.Value, Is.EqualTo(e2.Value));
            Assert.That(e2.Value, Is.EqualTo(e3.Value));
            Assert.That(e2.Value, Is.EqualTo(A.A));
        });

        e1.Init("0x02");
        e2.Init(A.C, new Types.Void());

        Assert.Multiple(() =>
        {
            Assert.That(e1.Value, Is.EqualTo(e2.Value));
            Assert.That(e2.Encode(), Is.EqualTo(e1.Encode()));
            Assert.That(e1.Value, Is.EqualTo(A.C));
        });
    }

    [Test]
    public void EnumWithData()
    {
        var e1 = new Enum<A, U8>();
        e1.Decode(new byte[] { 0x00, 0x01 });

        var e2 = new Enum<A, U8>();
        e2.Init(A.A, U8.From(1));

        Assert.Multiple(() =>
        {
            Assert.That(e1.Value, Is.EqualTo(A.A));
            Assert.That(e1.Encode(), Is.EqualTo(new byte[] { 0x00, 0x01 }));
            Assert.That(((U8)e1.Value2).Value, Is.EqualTo(1));
            Assert.That(e2.Value, Is.EqualTo(e1.Value));
            Assert.That(e2.Encode(), Is.EqualTo(e1.Encode()));
        });
    }
}

