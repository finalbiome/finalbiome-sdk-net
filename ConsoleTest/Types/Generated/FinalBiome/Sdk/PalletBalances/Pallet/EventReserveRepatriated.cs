///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances.Pallet
{
    /// <summary>
    /// Some balance was moved from the reserve of the first account to the second account.<br/>
    /// Final argument indicates the destination balance type.<br/>
    ///
    ///
    /// Generated from meta with Type Id 32, Variant Id 6
    /// </summary>
    public class EventReserveRepatriated : BaseType
    {
        public override string TypeName() => "EventReserveRepatriated";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 From { get; private set; }
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 To { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 Amount { get; private set; }
        public FinalBiome.Sdk.FrameSupport.Traits.Tokens.Misc.BalanceStatus DestinationStatus { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            From = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            From.Decode(byteArray, ref p);

            To = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            To.Decode(byteArray, ref p);

            Amount = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);

            DestinationStatus = new FinalBiome.Sdk.FrameSupport.Traits.Tokens.Misc.BalanceStatus();
            DestinationStatus.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
