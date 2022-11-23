using System;
using System.Collections;

namespace FinalBiome.Api.Types.Primitive
{
    public class I8 : Number<sbyte>, IFromNative<I8, sbyte>
    {
        public override int TypeSize => 1;
        public override string TypeName() => "i8";

        public override void Init(sbyte value)
        {
            Bytes = new byte[] { (byte)value };
            Value = value;
        }

        public override void Init(byte[] bytes)
        {
            Bytes = bytes;
            Value = (sbyte)bytes[0];
        }

        public static I8 From(sbyte value)
        {
            var val = new I8();
            val.Init(value);
            return val;
        }

        public static implicit operator sbyte(I8 v) => v.Value;
        public static explicit operator I8(sbyte v) => From(v);
    }
}

