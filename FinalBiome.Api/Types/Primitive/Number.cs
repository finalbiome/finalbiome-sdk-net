using System;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Types.Primitive
{
    public abstract class Number<T> : Primitive<T>
    {
        public override byte[] Encode() => Bytes;

        public override void InitFromHex(string hexString)
        {
            var bytes = HexUtils.HexToBytes(hexString, true);
            Array.Reverse(bytes);
            var result = new byte[TypeSize];
            bytes.CopyTo(result, 0);
            Init(result);
        }
    }
}

