using Newtonsoft.Json;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
using FinalBiome.Api.Rpc.JsonConverters;

namespace FinalBiome.Api.Test;

public class CodecTypeConverterTests
{
    [Test]
    public void U8Test()
    {
        string json = "\"0x01\"";
        U8? val = JsonConvert.DeserializeObject<U8>(json, new PrimitiveCodecTypeConverter<U8>());

        Assert.That(val?.Value, Is.EqualTo(1));
    }

    [Test]
    public void BoolTest()
    {
        string json = "\"0x01\"";
        Bool? val = JsonConvert.DeserializeObject<Bool>(json, new PrimitiveCodecTypeConverter<Bool>());

        Assert.That(val?.Value, Is.EqualTo(true));
    }

    [Test]
    public void U16Test()
    {
        string json = "\"0x42f1\"";
        U16? val = JsonConvert.DeserializeObject<U16>(json, new PrimitiveCodecTypeConverter<U16>());

        Assert.That(val?.Value, Is.EqualTo((short)0x42f1));
        // TODO: Check correctness of inversioning a hex string from json
        //U16 val2 = new U16();
        //val2.Init("0x42f1");
        //Assert.That(val2?.Value, Is.EqualTo((short)0x42f1));
    }

    [Test]
    public void U32Test()
    {
        string json = "\"0xf142bca0\"";
        U32? val = JsonConvert.DeserializeObject<U32>(json, new PrimitiveCodecTypeConverter<U32>());

        Assert.That(val?.Value, Is.EqualTo((uint)0xf142bca0));
        // TODO: Check correctness of inversioning a hex string from json
    }

    [Test]
    public void U64Test()
    {
        string json = "\"0x01de99faf142bca0\"";
        U64? val = JsonConvert.DeserializeObject<U64>(json, new PrimitiveCodecTypeConverter<U64>());

        Assert.That(val?.Value, Is.EqualTo((ulong)0x01de99faf142bca0));
        // TODO: Check correctness of inversioning a hex string from json
    }

    [Test]
    public void VecU8Test()
    {
        string json = "\"0x200101020304050607\"";
        Vec<U8>? val = JsonConvert.DeserializeObject<Vec<U8>>(json, new PrimitiveCodecTypeConverter<Vec<U8>>());

        Assert.That(val?.Value[0].Value, Is.EqualTo(1));
        Assert.That(val?.Value[1].Value, Is.EqualTo(1));
        Assert.That(val?.Value[2].Value, Is.EqualTo(2));
        Assert.That(val?.Value[3].Value, Is.EqualTo(3));
        Assert.That(val?.Value[4].Value, Is.EqualTo(4));
        Assert.That(val?.Value[5].Value, Is.EqualTo(5));
        Assert.That(val?.Value[6].Value, Is.EqualTo(6));
        Assert.That(val?.Value[7].Value, Is.EqualTo(7));
    }
}

