using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Test;

public class OptionTests
{
    [Test]
    public void OptionTest()
  {
    var optionU8Null = new Option<U8>();
        var optionU8One = new Option<U8>();

        optionU8Null.Init("0x00");
        optionU8One.Init("0x0100");
        Assert.Multiple(() =>
        {
            Assert.That(optionU8Null.Value, Is.EqualTo(null));
            Assert.That(optionU8One?.Value?.Value, Is.EqualTo(0));

            Assert.That(HexUtils.Bytes2HexString(optionU8Null.Bytes), Is.EqualTo("0x00"));
            Assert.That(HexUtils.Bytes2HexString(optionU8One!.Bytes), Is.EqualTo("0x0100"));
        });
    }
}


