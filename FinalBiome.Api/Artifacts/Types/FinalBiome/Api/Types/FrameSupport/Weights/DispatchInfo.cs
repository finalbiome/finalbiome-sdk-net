///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.FrameSupport.Weights
{
    /// <summary>
    /// Generated from meta with Type Id 19
    /// </summary>
    public class DispatchInfo : Codec
    {
        public override string TypeName() => "DispatchInfo";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U64 Weight { get; private set; }
        public FinalBiome.Api.Types.FrameSupport.Weights.DispatchClass Class { get; private set; }
        public FinalBiome.Api.Types.FrameSupport.Weights.Pays PaysFee { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Weight.Encode());
            bytes.AddRange(Class.Encode());
            bytes.AddRange(PaysFee.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Weight = new FinalBiome.Api.Types.Primitive.U64();
            Weight.Decode(byteArray, ref p);

            Class = new FinalBiome.Api.Types.FrameSupport.Weights.DispatchClass();
            Class.Decode(byteArray, ref p);

            PaysFee = new FinalBiome.Api.Types.FrameSupport.Weights.Pays();
            PaysFee.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
