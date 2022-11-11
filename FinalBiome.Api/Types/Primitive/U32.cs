using System;
using System.Collections;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Types.Primitive
{
    public class U32 : Number<uint>, IFromNative<U32, uint>
    {
        public override int TypeSize => 4;
        public override string TypeName() => "u32";

        public static U32 From(uint value)
        {
            var val = new U32();
            val.Init(value);
            return val;
        }

        public override void Init(uint value)
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
            Value = BitConverter.ToUInt32(bytes, 0);
        }
    }
}

