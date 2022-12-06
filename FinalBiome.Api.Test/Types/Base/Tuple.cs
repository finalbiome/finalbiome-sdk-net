using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Test;

public class TupleTests
{
    [Test]
    public void TupleDecode()
    {
        var t1 = new Types.Tuple<U16>();
        t1.Init("0x2a00");
        Assert.That(t1.Value, Has.Length.EqualTo(1));

        var t2 = new Types.Tuple<U16, U16>();
        t2.Init("0x2a002a00");
        Assert.That(t2.Value, Has.Length.EqualTo(2));

        var t3 = new Types.Tuple<U16, U16, U16>();
        t3.Init("0x2a002a002a00");
        Assert.That(t3.Value, Has.Length.EqualTo(3));
    }

    [Test]
    public void TupleInnt()
    {
        var u16 = new U16();
        u16.Init("0x2a00");

        var u32 = new U32();
        u32.Init("0xffffff00");

        var tupleOfTwo_1 = new Types.Tuple<U16, U32>();
        tupleOfTwo_1.Init(u16, u32);

        Assert.That(HexUtils.Bytes2HexString(tupleOfTwo_1.Encode()), Is.EqualTo("0x2A00FFFFFF00"));

        var tupleOfTwo_2 = new Types.Tuple<U16, U32>();
        tupleOfTwo_2.Init("0x2A00FFFFFF00");
        Assert.Multiple(() =>
        {
            Assert.That(((U16)tupleOfTwo_2.Value[0]).Value, Is.EqualTo(u16.Value));
            Assert.That(((U32)tupleOfTwo_2.Value[1]).Value, Is.EqualTo(u32.Value));
        });
    }
}

