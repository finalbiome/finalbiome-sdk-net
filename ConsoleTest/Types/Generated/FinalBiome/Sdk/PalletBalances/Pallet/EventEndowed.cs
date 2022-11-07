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
    /// An account was created with some free balance.<br/>
    ///
    ///
    /// Generated from meta with Type Id 32, Variant Id 0
    /// </summary>
    public class EventEndowed : BaseType
    {
        public override string TypeName() => "EventEndowed";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Account { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 FreeBalance { get; private set; }
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

            FreeBalance = new Ajuna.NetApi.Model.Types.Primitive.U128();
            FreeBalance.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
