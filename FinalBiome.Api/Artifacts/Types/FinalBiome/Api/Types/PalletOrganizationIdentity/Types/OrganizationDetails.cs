///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletOrganizationIdentity.Types
{
    /// <summary>
    /// Generated from meta with Type Id 169
    /// </summary>
    public class OrganizationDetails : Codec
    {
        public override string TypeName() => "OrganizationDetails";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.BoundedVecU8 Name { get; private set; }
        public FinalBiome.Api.Types.OptionBoundedVecAirDropAsset OnboardingAssets { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Name.Encode());
            bytes.AddRange(OnboardingAssets.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new FinalBiome.Api.Types.BoundedVecU8();
            Name.Decode(byteArray, ref p);

            OnboardingAssets = new FinalBiome.Api.Types.OptionBoundedVecAirDropAsset();
            OnboardingAssets.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
