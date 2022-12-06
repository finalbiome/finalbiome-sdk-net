using System;
using System.Collections;

namespace FinalBiome.Api.Types.Primitive
{
    public class I32 : Number<int>, IFromNative<I32, int>
    {
        public override int TypeSize => 4;
        public override string TypeName() => "i32";

        public static I32 From(int value)
        {
            var val = new I32();
            val.Init(value);
            return val;
        }

        public override void Init(int value)
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
            Value = BitConverter.ToInt32(bytes, 0);
        }

        public static implicit operator int(I32 v) => v.Value;
        public static implicit operator I32(int v) => From(v);
    }
}

