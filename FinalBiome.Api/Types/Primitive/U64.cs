using System;
using System.Collections;

namespace FinalBiome.Api.Types.Primitive
{
    public class U64 : Number<ulong>, IFromNative<U64, ulong>
    {
        public override int TypeSize => 8;
        public override string TypeName() => "u64";

        public override void Init(ulong value)
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
            Value = BitConverter.ToUInt64(bytes, 0);
        }

        public static U64 From(ulong value)
        {
            var val = new U64();
            val.Init(value);
            return val;
        }

        public static implicit operator ulong(U64 v) => v.Value;
        public static explicit operator U64(ulong v) => From(v);
    }
}

