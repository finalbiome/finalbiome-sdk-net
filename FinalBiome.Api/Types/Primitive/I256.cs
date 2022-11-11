using System;
using System.Collections;
using System.Numerics;

namespace FinalBiome.Api.Types.Primitive
{
    public class I256 : Number<BigInteger>, IFromNative<I256, BigInteger>
    {
        public override int TypeSize => 32;
        public override string TypeName() => "i256";

        public override void Init(BigInteger value)
        {
            throw new NotImplementedException();
        }

        public override void Init(byte[] bytes)
        {
            if (bytes.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                bytes.CopyTo(newByteArray, 0);
                bytes = newByteArray;
            }

            Bytes = bytes;
            Value = new BigInteger(bytes);
        }

        public static I256 From(BigInteger value)
        {
            var val = new I256();
            val.Init(value);
            return val;
        }

    }
}

