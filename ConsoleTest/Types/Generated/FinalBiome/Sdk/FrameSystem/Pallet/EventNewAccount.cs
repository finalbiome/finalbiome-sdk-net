///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Pallet
{
    /// <summary>
    /// A new account was created.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18, Variant Id 3
    /// </summary>
    public class EventNewAccount : BaseType
    {
        public override string TypeName() => "EventNewAccount";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Account { get; private set; }
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

            _size = p - start;
        }
    }
}
