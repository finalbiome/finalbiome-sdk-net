using System;
using System.Collections;
using System.Numerics;

namespace FinalBiome.Api.Types.Primitive
{
    public class I128 : Number<BigInteger>, IFromNative<I128, BigInteger>
    {
        public override int TypeSize => 16;
        public override string TypeName() => "i128";

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

        public static I128 From(BigInteger value)
        {
            var val = new I128();
            val.Init(value);
            return val;
        }

        public static implicit operator BigInteger(I128 v) => v.Value;
        public static implicit operator I128(BigInteger v) => From(v);
    }
}

