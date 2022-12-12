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
namespace FinalBiome.Api.Types.FinalityGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 115
    /// </summary>
    public class Precommit : Codec
    {
        public override string TypeName() => "Precommit";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PrimitiveTypes.H256 TargetHash { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 TargetNumber { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(TargetHash.Encode());
            bytes.AddRange(TargetNumber.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TargetHash = new FinalBiome.Api.Types.PrimitiveTypes.H256();
            TargetHash.Decode(byteArray, ref p);

            TargetNumber = new FinalBiome.Api.Types.Primitive.U32();
            TargetNumber.Decode(byteArray, ref p);

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
