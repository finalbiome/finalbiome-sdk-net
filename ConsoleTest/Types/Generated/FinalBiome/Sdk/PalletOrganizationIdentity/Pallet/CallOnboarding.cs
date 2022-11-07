///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletOrganizationIdentity.Pallet
{
    /// <summary>
    /// Onboirding to game<br/>
    ///
    ///
    /// Generated from meta with Type Id 131, Variant Id 4
    /// </summary>
    public class CallOnboarding : BaseType
    {
        public override string TypeName() => "CallOnboarding";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 OrganizationId { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OrganizationId = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            OrganizationId.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
