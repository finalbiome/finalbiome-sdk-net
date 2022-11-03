///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances
{
    /// <summary>
    /// Generated from meta with Type Id 113
    /// </summary>
    public class BalanceLock : BaseType
    {
        public override string TypeName() => "BalanceLock";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.Model.Types.Base.Array8U8 Id { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 Amount { get; private set; }
        public FinalBiome.Sdk.PalletBalances.Reasons Reasons { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Id = new FinalBiome.Sdk.Model.Types.Base.Array8U8();
            Id.Decode(byteArray, ref p);

            Amount = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);

            Reasons = new FinalBiome.Sdk.PalletBalances.Reasons();
            Reasons.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
