using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Types
{
    public class Vec<T> : Codec where T : Codec, new()
    {
        public override string TypeName() => $"Vec<{new T().TypeName()}>";
        public T[] Value { get; internal set; }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(CompactNum.CompactTo(Value.Length));

            for (int i = 0; i < Value.Length; i++)
            {
                result.AddRange(Value[i].Encode());
            }
            return result.ToArray();
        }

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            var length = (int)CompactNum.CompactFrom(bytes, ref pos);

            var array = new T[length];
            for (var i = 0; i < length; i++)
            {
                var t = new T();
                t.Decode(bytes, ref pos);
                array[i] = t;
            }

            TypeSize = pos - start;

            Bytes = new byte[TypeSize];
            Array.Copy(bytes, start, Bytes, 0, TypeSize);
            Value = array;
        }

        public void Init(T[] values)
        {
            Value = values;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }
        
    }
}

