using System.Text;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Types.Primitive
{
    public class Str : Primitive<string>, IFromNative<Str, string>
    {
        public override string TypeName() => "str";

        public override byte[] Encode()
        {
            return ArrayUtils.SizePrefixedByteArray(Encoding.UTF8.GetBytes(Value));
        }

        public override void Decode(byte[] byteArray, ref int pos)
        {
            var start = pos;

            var value = String.Empty;

            //var length = CompactInteger.Decode(byteArray, ref pos);
            var length = CompactNum.CompactFrom(byteArray, ref pos);
            for (var i = 0; i < length; i++)
            {
                var t = Char.Decode<Char>(byteArray, ref pos);
                value += t.Value;
            }

            TypeSize = pos - start;

            var bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, bytes, 0, TypeSize);

            Bytes = bytes;
            Value = value;
        }

        public override void Init(string value)
        {
            Value = value;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }

        public static Str From(string value)
        {
            var val = new Str();
            val.Init(value);
            return val;
        }


    }
}

