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
    /// Generated from meta with Type Id 86
    /// </summary>
    public class PerDispatchClass : Codec
    {
        public override string TypeName() => "PerDispatchClass";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U32 Normal { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Operational { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Mandatory { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Normal.Encode());
            bytes.AddRange(Operational.Encode());
            bytes.AddRange(Mandatory.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Normal = new FinalBiome.Api.Types.Primitive.U32();
            Normal.Decode(byteArray, ref p);

            Operational = new FinalBiome.Api.Types.Primitive.U32();
            Operational.Decode(byteArray, ref p);

            Mandatory = new FinalBiome.Api.Types.Primitive.U32();
            Mandatory.Decode(byteArray, ref p);

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
