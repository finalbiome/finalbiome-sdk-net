///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FinalityGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 107
    /// </summary>
    public class Equivocation : BaseComposite
    {
        public override string TypeName() => "Equivocation";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U64 RoundNumber { get; private set; }
        public FinalBiome.Sdk.SpFinalityGrandpa.App.Public Identity { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.Tuple_Precommit_Signature First { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.Tuple_Precommit_Signature Second { get; private set; }
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

            RoundNumber = new Ajuna.NetApi.Model.Types.Primitive.U64();
            RoundNumber.Decode(byteArray, ref p);

            Identity = new FinalBiome.Sdk.SpFinalityGrandpa.App.Public();
            Identity.Decode(byteArray, ref p);

            First = new FinalBiome.Sdk.Model.Types.Base.Tuple_Precommit_Signature();
            First.Decode(byteArray, ref p);

            Second = new FinalBiome.Sdk.Model.Types.Base.Tuple_Precommit_Signature();
            Second.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
