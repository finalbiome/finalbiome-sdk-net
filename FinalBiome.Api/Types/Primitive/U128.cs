using System;
using System.Collections;
using System.Numerics;

namespace FinalBiome.Api.Types.Primitive
{
    public class U128 : Number<BigInteger>, IFromNative<U128, BigInteger>
    {
        public override int TypeSize => 16;
        public override string TypeName() => "u128";

        public override void Init(BigInteger value)
        {
            var byteArray = value.ToByteArray();

            if (byteArray.Length > TypeSize)
            {
                throw new Exception($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            var bytes = new byte[TypeSize];
            byteArray.CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
        }

        public override void Init(byte[] bytes)
        {
            // make sure it is unsigned we add 00 at the end
            if (bytes.Length < TypeSize)
            {
                var newByteArray = new byte[TypeSize];
                bytes.CopyTo(newByteArray, 0);
                bytes = newByteArray;
            }
            else if (bytes.Length == TypeSize)
            {
                byte[] newArray = new byte[bytes.Length + 2];
                bytes.CopyTo(newArray, 0);
                newArray[bytes.Length - 1] = 0x00;
            }
            else
            {
                throw new Exception($"Wrong byte array size for {TypeName()}, max. {TypeSize} bytes!");
            }

            Bytes = bytes;
            Value = new BigInteger(bytes);
        }

        public static U128 From(BigInteger value)
        {
            var val = new U128();
            val.Init(value);
            return val;
        }
    }
}

