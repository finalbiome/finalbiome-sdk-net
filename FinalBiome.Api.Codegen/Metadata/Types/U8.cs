using System;
using System.Collections;

namespace FinalBiome.Api.Codegen.Metadata
{
    public class U8 : Number<byte>
    {
        public override int TypeSize => 1;
        public override string TypeName() => "u8";

        public override void Init(byte value)
        {
            Bytes = new byte[] { value };
            Value = value;
        }

        public override void Init(byte[] bytes)
        {
            Bytes = bytes;
            Value = bytes[0];
        }

        public static U8 From(byte value)
        {
            var val = new U8();
            val.Init(value);
            return val;
        }
    }
}

