using System;
using System.Collections;
using Newtonsoft.Json;

namespace FinalBiome.Api.Codegen.Metadata
{
    public class Option<T> : Codec where T : Codec, new()
    {
        public override string TypeName() => $"Option<{new T().TypeName()}>";

        [JsonIgnore]
        public bool IsSome { get; set; }
        [JsonIgnore]
        public bool IsNone => !IsSome;
        public T? Value { get; internal set; }

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            if (IsSome)
            {
                bytes.Add(1);
                bytes.AddRange(Value!.Encode());
            }
            else
            {
                bytes.Add(0);
            }

            return bytes.ToArray();
        }

        public override void Decode(byte[] bytes, ref int pos)
        {
            var start = pos;

            var optionByte = new U8();
            optionByte.Decode(bytes, ref pos);

            IsSome = optionByte.Value > 0;

            T? t = default;
            if (optionByte.Value > 0)
            {
                t = new T();
                t.Decode(bytes, ref pos);
            }

            TypeSize = pos - start;

            var innerBytes = new byte[TypeSize];
            Array.Copy(bytes, start, innerBytes, 0, TypeSize);

            Bytes = innerBytes;
            Value = t == null ? default : t;
        }

        public void Init(T? value)
        {
            IsSome = value != null;
            Value = value;
            Bytes = Encode();
            TypeSize = Bytes.Length;
        }
    }
}

