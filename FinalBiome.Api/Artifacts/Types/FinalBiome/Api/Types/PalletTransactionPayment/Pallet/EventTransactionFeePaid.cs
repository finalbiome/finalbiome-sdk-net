///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletTransactionPayment.Pallet
{
    /// <summary>
    /// A transaction fee `actual_fee`, of which `tip` was added to the minimum inclusion fee,<br/>
    /// has been paid by `who`.<br/>
    ///
    ///
    /// Generated from meta with Type Id 34, Variant Id 0
    /// </summary>
    public class EventTransactionFeePaid : Codec
    {
        public override string TypeName() => "EventTransactionFeePaid";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Who { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 ActualFee { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 Tip { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Who = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Who.Decode(byteArray, ref p);

            ActualFee = new FinalBiome.Api.Types.Primitive.U128();
            ActualFee.Decode(byteArray, ref p);

            Tip = new FinalBiome.Api.Types.Primitive.U128();
            Tip.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
