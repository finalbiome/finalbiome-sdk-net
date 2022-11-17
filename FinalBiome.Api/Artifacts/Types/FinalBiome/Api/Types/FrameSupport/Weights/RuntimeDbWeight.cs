///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.FrameSupport.Weights
{
    /// <summary>
    /// Generated from meta with Type Id 79
    /// </summary>
    public class RuntimeDbWeight : Codec
    {
        public override string TypeName() => "RuntimeDbWeight";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U64 Read { get; private set; }
        public FinalBiome.Api.Types.Primitive.U64 Write { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Read.Encode());
            bytes.AddRange(Write.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Read = new FinalBiome.Api.Types.Primitive.U64();
            Read.Decode(byteArray, ref p);

            Write = new FinalBiome.Api.Types.Primitive.U64();
            Write.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
