using System;
using System.Collections;

namespace FinalBiome.Api.Types.Primitive
{
    public class I16 : Number<short>, IFromNative<I16, short>
    {
        public override int TypeSize => 2;
        public override string TypeName() => "i16";

        public override void Init(short value)
        {
            var bytes = new byte[TypeSize];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            Bytes = bytes;
            Value = value;
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
            Value = BitConverter.ToInt16(bytes, 0);
        }

        public static I16 From(short value)
        {
            var val = new I16();
            val.Init(value);
            return val;
        }

        public static implicit operator short(I16 v) => v.Value;
        public static explicit operator I16(short v) => From(v);
    }
}

