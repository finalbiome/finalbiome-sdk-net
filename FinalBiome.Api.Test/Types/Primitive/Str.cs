using System;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Test;

public class StrTests
{
    [Test]
    public void StrTest()
    {
        var vecChar = new char[] { 'b', 'a', 'n', 'a', 'n', 'e' };
        var primVec = new Str();
        primVec.Init(HexUtils.HexToBytes("0x1862616e616e65"));
        for (int i = 0; i < vecChar.Length; i++)
        {
            Assert.That(primVec.Value.ToCharArray()[i], Is.EqualTo(vecChar[i]));
        }
    }
}

