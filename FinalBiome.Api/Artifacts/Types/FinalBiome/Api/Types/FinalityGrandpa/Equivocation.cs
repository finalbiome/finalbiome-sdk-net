///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.FinalityGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 107
    /// </summary>
    public class Equivocation : Codec
    {
        public override string TypeName() => "Equivocation";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U64 RoundNumber { get; private set; }
        public FinalBiome.Api.Types.SpFinalityGrandpa.App.Public Identity { get; private set; }
        public FinalBiome.Api.Types.Tuple_Precommit_Signature First { get; private set; }
        public FinalBiome.Api.Types.Tuple_Precommit_Signature Second { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(RoundNumber.Encode());
            bytes.AddRange(Identity.Encode());
            bytes.AddRange(First.Encode());
            bytes.AddRange(Second.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            RoundNumber = new FinalBiome.Api.Types.Primitive.U64();
            RoundNumber.Decode(byteArray, ref p);

            Identity = new FinalBiome.Api.Types.SpFinalityGrandpa.App.Public();
            Identity.Decode(byteArray, ref p);

            First = new FinalBiome.Api.Types.Tuple_Precommit_Signature();
            First.Decode(byteArray, ref p);

            Second = new FinalBiome.Api.Types.Tuple_Precommit_Signature();
            Second.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}