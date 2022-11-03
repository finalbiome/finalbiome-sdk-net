///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport.Characteristics.Bettor
{
    /// <summary>
    /// Generated from meta with Type Id 151
    /// </summary>
    public class BettorOutcome : BaseType
    {
        public override string TypeName() => "BettorOutcome";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.BoundedVecU8 Name { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Probability { get; private set; }
        public FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.OutcomeResult Result { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new FinalBiome.Sdk.BoundedVecU8();
            Name.Decode(byteArray, ref p);

            Probability = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Probability.Decode(byteArray, ref p);

            Result = new FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.OutcomeResult();
            Result.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
