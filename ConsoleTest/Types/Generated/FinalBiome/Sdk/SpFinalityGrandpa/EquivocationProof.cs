///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.SpFinalityGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 99
    /// </summary>
    public class EquivocationProof : BaseType
    {
        public override string TypeName() => "EquivocationProof";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U64 SetId { get; private set; }
        public FinalBiome.Sdk.SpFinalityGrandpa.Equivocation Equivocation { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            SetId = new Ajuna.NetApi.Model.Types.Primitive.U64();
            SetId.Decode(byteArray, ref p);

            Equivocation = new FinalBiome.Sdk.SpFinalityGrandpa.Equivocation();
            Equivocation.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
