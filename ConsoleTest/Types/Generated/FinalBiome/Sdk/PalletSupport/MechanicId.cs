///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport
{
    /// <summary>
    /// Generated from meta with Type Id 165
    /// </summary>
    public class MechanicId : BaseType
    {
        public override string TypeName() => "MechanicId";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 AccountId { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Nonce { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            AccountId = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            AccountId.Decode(byteArray, ref p);

            Nonce = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Nonce.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
