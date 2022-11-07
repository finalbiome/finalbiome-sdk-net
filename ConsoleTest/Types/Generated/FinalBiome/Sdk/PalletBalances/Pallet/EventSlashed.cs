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
    /// Some amount was removed from the account (e.g. for misbehavior).<br/>
    ///
    ///
    /// Generated from meta with Type Id 32, Variant Id 9
    /// </summary>
    public class EventSlashed : BaseType
    {
        public override string TypeName() => "EventSlashed";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Who { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 Amount { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Who = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            Who.Decode(byteArray, ref p);

            Amount = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
