using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Test;

public class VecTests
{
    [Test]
    public void VecU16Test()
    {
        var vecUInt16 = new uint[] { 4, 8, 15, 16, 23, 42 };
        var v = new Vec<U16>();
        v.Init("0x18040008000f00100017002a00");
        for (int i = 0; i < vecUInt16.Length; i++)
        {
            Assert.That(v.Value[i].Value, Is.EqualTo(vecUInt16[i]));
        }
    }
}

