using System;
namespace FinalBiome.Api.Codegen.Metadata
{
    public abstract class Primitive<T> : Codec
    {
        public abstract void Init(T value);
#pragma warning disable CS8618
        public virtual T Value { get; set; }
#pragma warning restore CS8618

        public override void Decode(byte[] byteArray, ref int pos)
        {
            var memory = byteArray.AsMemory();
            var result = memory.Span.Slice(pos, TypeSize).ToArray();
            pos += TypeSize;
            Init(result);
        }
    }
}

