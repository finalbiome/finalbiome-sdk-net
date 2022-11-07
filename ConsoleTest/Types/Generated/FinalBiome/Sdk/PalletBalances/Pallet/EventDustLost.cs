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
    /// An account was removed whose balance was non-zero but below ExistentialDeposit,<br/>
    /// resulting in an outright loss.<br/>
    ///
    ///
    /// Generated from meta with Type Id 32, Variant Id 1
    /// </summary>
    public class EventDustLost : BaseType
    {
        public override string TypeName() => "EventDustLost";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Account { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 Amount { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Account = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            Account.Decode(byteArray, ref p);

            Amount = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
