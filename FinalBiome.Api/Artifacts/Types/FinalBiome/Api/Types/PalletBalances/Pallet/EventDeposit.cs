///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletBalances.Pallet
{
    /// <summary>
    /// Some amount was deposited (e.g. for transaction fees).<br/>
    ///
    ///
    /// Generated from meta with Type Id 32, Variant Id 7
    /// </summary>
    public class EventDeposit : Codec
    {
        public override string TypeName() => "EventDeposit";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Who { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 Amount { get; private set; }
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

            Amount = new FinalBiome.Api.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
