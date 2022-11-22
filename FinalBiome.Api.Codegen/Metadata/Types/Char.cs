using System;
using System.Collections;
using System.Text;

namespace FinalBiome.Api.Codegen.Metadata
{
    public class Char : Primitive<char>
    {
        public override string TypeName() => "char";
        public override int TypeSize => 1;

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Init(byte[] bytes)
        {
            Bytes = bytes;
            Value = Encoding.UTF8.GetString(bytes)[0];
        }

        public override void Init(char value)
        {
            Bytes = Encoding.UTF8.GetBytes(value.ToString());
            Value = value;
        }

        public static Char From(char value)
        {
            var val = new Char();
            val.Init(value);
            return val;
        }
    }
}

