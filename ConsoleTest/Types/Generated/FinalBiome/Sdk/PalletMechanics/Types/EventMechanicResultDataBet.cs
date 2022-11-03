///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Types
{
    /// <summary>
    /// Generated from meta with Type Id 55
    /// </summary>
    public class EventMechanicResultDataBet : BaseType
    {
        public override string TypeName() => "EventMechanicResultDataBet";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.BoundedVecU32 Outcomes { get; private set; }
        public FinalBiome.Sdk.PalletMechanics.Types.BetResult Result { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Outcomes = new FinalBiome.Sdk.BoundedVecU32();
            Outcomes.Decode(byteArray, ref p);

            Result = new FinalBiome.Sdk.PalletMechanics.Types.BetResult();
            Result.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
