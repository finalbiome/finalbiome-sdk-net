using System;
using System.Collections;

namespace FinalBiome.Api.Types.Primitive
{
    public class Bool : Primitive<bool>, IFromNative<Bool, bool>
    {
        public override int TypeSize => 1;
        public override string TypeName() => "bool";
        public override byte[] Encode() => Bytes;

        public override void Init(bool value)
        {
            Bytes = new byte[] { (byte)(value ? 0x01 : 0x00) };
            Value = value;
        }

        public override void Init(byte[] bytes)
        {
            Bytes = bytes;
            Value = bytes[0] != 0;
        }

        public static Bool From(bool value)
        {
            var val = new Bool();
            val.Init(value);
            return val;
        }

        public static implicit operator bool(Bool b) => b.Value;
        public static implicit operator Bool(bool b) => From(b);
    }
}

