using System;
namespace FinalBiome.Api.Types
{
    public abstract class Primitive<T> : Codec
    {
        public abstract void Init(T value);
#pragma warning disable CS8618
        public virtual T Value { get; set; }
#pragma warning restore CS8618
        public override void Decode(byte[] bytes, ref int pos)
        {
            var memory = bytes.AsMemory();
            var result = memory.Span.Slice(pos, TypeSize).ToArray();
            pos += TypeSize;
            Init(result);
        }
    }
}

