using System;
namespace FinalBiome.Api.Codegen.Metadata
{
    public abstract class Primitive<T> : Codec
    {
        public abstract void Init(T value);

        public virtual T Value { get; set; }

        public override void Decode(byte[] byteArray, ref int pos)
        {
            var memory = byteArray.AsMemory();
            var result = memory.Span.Slice(pos, TypeSize).ToArray();
            pos += TypeSize;
            Init(result);
        }
    }
}

