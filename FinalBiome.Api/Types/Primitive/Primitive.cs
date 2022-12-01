using System;
namespace FinalBiome.Api.Types
{
    public abstract class Primitive<T> : Codec
    {
        public abstract void Init(T value);

        public virtual T Value { get; set; }

        public override void Decode(byte[] bytes, ref int pos)
        {
            var memory = bytes.AsMemory();
            var result = memory.Span.Slice(pos, TypeSize).ToArray();
            pos += TypeSize;
            Init(result);
        }
    }
}

