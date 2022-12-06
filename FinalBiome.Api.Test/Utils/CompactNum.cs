#pragma warning disable IDE0230


namespace FinalBiome.Api.Test;

using System.Globalization;
using System.Numerics;
using FinalBiome.Api.Utils;

public class CompactNumTests
{
    [Test]
    public void CompactFromTo()
    {
        BigInteger[] array = { 0, 1, 255, 256, 65535, 4294967295, 4294967296, 8000000000000000000, 18446744073709551615 };
        foreach (var t in array)
        {
            Assert.That(CompactNum.CompactFrom(CompactNum.CompactTo(t)), Is.EqualTo(t));
        }

        for (var i = 0; i < 1000000; i += 13)
        {
            BigInteger bn = i;
            Assert.That(CompactNum.CompactFrom(CompactNum.CompactTo(bn)), Is.EqualTo(bn));
        }
    }

    [Test]
    public void CompactFromU8()
    {
        var bytes = new byte[] { 0b11111100 };
        BigInteger bn = 63;
        Assert.That(CompactNum.CompactFrom(bytes), Is.EqualTo(bn));
    }

    [Test]
    public void CompactFromU16()
    {
        var bytes = new byte[] { 0b11111101, 0b00000111 };
        BigInteger bn = 511;
        Assert.That(CompactNum.CompactFrom(bytes), Is.EqualTo(bn));
    }

    [Test]
    public void CompactFromU32()
    {
        var bytes = new byte[] { 254, 255, 3, 0 };
        BigInteger bn = 0xffff;
        Assert.That(CompactNum.CompactFrom(bytes), Is.EqualTo(bn));
    }

    [Test]
    public void CompactFromU32_2()
    {
        var bytes = new byte[] { 254, 255, 255, 255 };
        BigInteger bn = 1073741823;
        Assert.That(CompactNum.CompactFrom(bytes), Is.EqualTo(bn));
    }

    [Test]
    public void CompactFromU32_3()
    {
        var bytes = new byte[] { 3, 249, 255, 255, 255 };
        BigInteger bn = 0xfffffff9;
        Assert.That(CompactNum.CompactFrom(bytes), Is.EqualTo(bn));
    }

    [Test]
    public void CompactFromU32_4()
    {
        var bytes = new byte[] { 3 + ((4 - 4) << 2), 249, 255, 255, 255 };
        BigInteger bn = 0xfffffff9;
        Assert.That(CompactNum.CompactFrom(bytes), Is.EqualTo(bn));
    }

    [Test]
    public void CompactFromActual()
    {
        var bytes = HexUtils.HexToBytes("0x0284d717");
        BigInteger bn = 100000000;
        Assert.That(CompactNum.CompactFrom(bytes), Is.EqualTo(bn));
    }

    [Test]
    public void CompactToU8()
    {
        var bytes = CompactNum.CompactTo(18);
        Assert.That(bytes, Is.EqualTo(new byte[] { 18 << 2  }));
    }

    [Test]
    public void CompactToMaxU8()
    {
        var bytes = CompactNum.CompactTo(63);
        Assert.That(bytes, Is.EqualTo(new byte[] { 0b11111100 }));
    }

    [Test]
    public void CompactToU16()
    {
        var bytes = CompactNum.CompactTo(511);
        Assert.That(bytes, Is.EqualTo(new byte[] { 0b11111101, 0b00000111 }));
    }

    [Test]
    public void CompactToU16NotAtEdge()
    {
        var bytes = CompactNum.CompactTo(111);
        Assert.That(bytes, Is.EqualTo(new byte[] { 0xbd, 0x01 }));
    }

    [Test]
    public void CompactToU32()
    {
        var bytes = CompactNum.CompactTo(0x1fff);
        Assert.That(bytes, Is.EqualTo(new byte[] { 253, 127 }));
    }

    [Test]
    public void CompactToU32Short()
    {
        var bytes = CompactNum.CompactTo(0xffff);
        Assert.That(bytes, Is.EqualTo(new byte[] { 254, 255, 3, 0 }));
    }

    [Test]
    public void CompactToU32Full()
    {
        var bytes = CompactNum.CompactTo(0xfffffff9);
        Assert.That(bytes, Is.EqualTo(new byte[] { 3 + ((4 - 4) << 2), 249, 255, 255, 255 }));
    }

    [Test]
    public void CompactToLarge6Bytes()
    {
        BigInteger bn = BigInteger.Parse("00005af3107a4000", NumberStyles.AllowHexSpecifier);
        var bytes = CompactNum.CompactTo(bn);
        Assert.That(bytes, Is.EqualTo(new byte[] { 3 + ((6 - 4) << 2), 0x00, 0x40, 0x7a, 0x10, 0xf3, 0x5a }));
    }

    [Test]
    public void CompactToLarge9Bytes()
    {
        BigInteger bn = BigInteger.Parse("1200005af3107a4034", NumberStyles.AllowHexSpecifier);
        var bytes = CompactNum.CompactTo(bn);
        Assert.That(bytes, Is.EqualTo(new byte[] { 23, 52, 0x40, 0x7a, 0x10, 0xf3, 0x5a, 0, 0, 18 }));
    }

    [Test]
    public void DoesNotModifyOriginal()
    {
        BigInteger bn = new BigInteger(123456);
        var bytes = CompactNum.CompactTo(bn);
        Assert.Multiple(() =>
        {
            Assert.That(bytes, Is.EqualTo(new byte[] { 2, 137, 7, 0 }));
            Assert.That(bn.ToString(), Is.EqualTo("123456"));
        });
    }

    [Test]
    public void FromRust()
    {
        // // Copied from https://github.com/paritytech/parity-codec/blob/master/src/codec.rs
        var testCases = new (string, BigInteger)[]
        {
            ("00", BigInteger.Parse("0") ),
            ("fc", BigInteger.Parse("63") ),
            ("01 01", BigInteger.Parse("64") ),
            ("fd ff", BigInteger.Parse("16383") ),
            ("02 00 01 00", BigInteger.Parse("16384") ),
            ("fe ff ff ff", BigInteger.Parse("1073741823") ),
            ("03 00 00 00 40", BigInteger.Parse("1073741824") ),

      //{ expected: "03 ff ff ff ff", value: new BN(`${ 1 }${ "0".repeat(32)}`, 2).subn(1) },
      //{ expected: "07 00 00 00 00 01", value: new BN(`${ 1 }${ "0".repeat(32)}`, 2) },
      //{ expected: "0b 00 00 00 00 00 01", value: new BN(`${ 1 }${ "0".repeat(40)}`, 2) },
      //{ expected: "0f 00 00 00 00 00 00 01", value: new BN(`${ 1 }${ "0".repeat(48)}`, 2) },
      //{ expected: "0f ff ff ff ff ff ff ff", value: new BN(`${ 1 }${ "0".repeat(56)}`, 2).subn(1) },
      //{ expected: "13 00 00 00 00 00 00 00 01", value: new BN(`${ 1 }${ "0".repeat(56)}`, 2) },
      //{ expected: "13 ff ff ff ff ff ff ff ff", value: new BN(`${ 1 }${ "0".repeat(64)}`, 2).subn(1) }
        };

        foreach (var test in testCases)
        {
            var testVal = test.Item2;
            var bytes = test.Item1.Split(" ").Select(v => byte.Parse(v, System.Globalization.NumberStyles.HexNumber)).ToArray();
            Assert.That(CompactNum.CompactTo(testVal), Is.EqualTo(bytes));


        }
    }
}

