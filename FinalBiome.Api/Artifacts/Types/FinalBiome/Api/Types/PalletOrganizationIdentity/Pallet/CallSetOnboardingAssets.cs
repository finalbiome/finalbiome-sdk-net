///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet
{
    /// <summary>
    /// Set assets which will be airdroped at game onboarding<br/>
    ///
    ///
    /// Generated from meta with Type Id 131, Variant Id 3
    /// </summary>
    public class CallSetOnboardingAssets : Codec
    {
        public override string TypeName() => "CallSetOnboardingAssets";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 OrganizationId { get; private set; }
        public FinalBiome.Api.Types.OptionBoundedVecAirDropAsset Assets { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OrganizationId = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            OrganizationId.Decode(byteArray, ref p);

            Assets = new FinalBiome.Api.Types.OptionBoundedVecAirDropAsset();
            Assets.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
