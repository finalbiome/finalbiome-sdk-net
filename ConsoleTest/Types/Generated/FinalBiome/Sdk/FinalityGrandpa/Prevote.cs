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
    /// Generated from meta with Type Id 102
    /// </summary>
    public class Prevote : BaseType
    {
        public override string TypeName() => "Prevote";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PrimitiveTypes.H256 TargetHash { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 TargetNumber { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            TargetHash = new FinalBiome.Sdk.PrimitiveTypes.H256();
            TargetHash.Decode(byteArray, ref p);

            TargetNumber = new Ajuna.NetApi.Model.Types.Primitive.U32();
            TargetNumber.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
