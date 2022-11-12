using System;
using System.Numerics;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Utils
{
    /// <summary>
    /// TODO: Refactor this with respect to https://github.com/polkadot-js/common/tree/master/packages/util/src/compact
    /// </summary>
    public static class CompactNum
    {
        //public BigInteger Value { get; internal set; }

        //static public CompactNum From<T>(Number<T> value) where T : INumber<T>
        //{
        //    CompactNum c = new CompactNum();
        //    c.Value = value.Value;
        //    return c;
        //}

        public static BigInteger CompactFrom(byte[] bytes)
        {
            var p = 0;
            return CompactNum.CompactFrom(bytes, ref p);
        }

        public static BigInteger CompactFrom(byte[] bytes, ref int pos)
        {
            uint firstByte = bytes[pos++];
            var flag = firstByte & 0b00000011u;
            BigInteger number = 0u;

            switch (flag)
            {
                case 0b00u:
                    {
                        number = firstByte >> 2;
                        break;
                    }

                case 0b01u:
                    {
                        uint secondByte = bytes[pos++];

                        number = ((firstByte & 0b11111100u) + secondByte * 256u) >> 2;
                        break;
                    }

                case 0b10u:
                    {
                        number = firstByte;
                        var multiplier = 256u;

                        for (var i = 0; i < 3; ++i)
                        {
                            number += bytes[pos++] * multiplier;
                            multiplier = multiplier << 8;
                        }

                        number = number >> 2;
                        break;
                    }

                case 0b11:
                    {
                        var bytesCount = (firstByte >> 2) + 4u;
                        BigInteger multiplier = 1u;
                        BigInteger val = 0;

                        // we assured that there are m more bytes,
                        // no need to make checks in a loop
                        for (var i = 0; i < bytesCount; ++i)
                        {
                            val += multiplier * bytes[pos++];
                            multiplier *= 256u;
                        }

                        return val;
                    }
            }

            return number;
        }

        public static byte[] CompactTo(BigInteger value)
        {
            if (value <= 63) return new byte[] { (byte)(value << 2) };

            if (value <= 0x3FFF)
                return new byte[]
                {
                    (byte)(((value & 0x3F) << 2) | 0x01),
                    (byte)((value & 0xFFC0) >> 6)
                };

            if (value <= 0x3FFFFFFF)
            {
                var result = new byte[4];
                result[0] = (byte)(((value & 0x3F) << 2) | 0x02);
                value >>= 6;
                for (var i = 1; i < 4; ++i)
                {
                    result[i] = (byte)(value & 0xFF);
                    value >>= 8;
                }

                return result;
            }
            else
            {
                var b0 = new List<byte>();
                while (value > 0)
                {
                    b0.Add((byte)(value & 0xFF));
                    value >>= 8;
                }

                var result = new List<byte>
                {
                    (byte) (((b0.Count - 4) << 2) | 0x03)
                };
                result.AddRange(b0);
                return result.ToArray();
            }
        }
    }
}

