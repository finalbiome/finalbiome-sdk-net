using System;
using System.Collections;

namespace FinalBiome.Api.Types.Primitive
{
    public class I64 : Number<long>, IFromNative<I64, long>
    {
        public override int TypeSize => 8;
        public override string TypeName() => "i64";

        public override void Init(long value)
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
            Value = BitConverter.ToInt64(bytes, 0);
        }

        public static I64 From(long value)
        {
            var val = new I64();
            val.Init(value);
            return val;
        }

        public static implicit operator long(I64 v) => v.Value;
        public static explicit operator I64(long v) => From(v);
    }
}

