using System;
using System.Collections;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Types.Primitive
{
    public class U16 : Number<ushort>, IFromNative<U16, ushort>
    {
        public override int TypeSize => 2;
        public override string TypeName() => "u16";

        public override void Init(ushort value)
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
            Value = BitConverter.ToUInt16(bytes, 0);
        }

        public static U16 From(ushort value)
        {
            var val = new U16();
            val.Init(value);
            return val;
        }

        public static implicit operator ushort(U16 v) => v.Value;
        public static implicit operator U16(ushort v) => From(v);
    }
}

