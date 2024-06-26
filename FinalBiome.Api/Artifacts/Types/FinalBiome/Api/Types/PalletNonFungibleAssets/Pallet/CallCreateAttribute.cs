///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    /// Creates an attribute for the non fungible asset class.<br/>
    /// The origin must be Signed, be a member of the organization<br/>
    /// and that organization must be a owner of the asset class.<br/>
    ///
    ///
    /// Generated from meta with Type Id 154, Variant Id 2
    /// </summary>
    public class CallCreateAttribute : Codec
    {
        public override string TypeName() => "CallCreateAttribute";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress OrganizationId { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId ClassId { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Attribute Attribute { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OrganizationId = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            OrganizationId.Decode(byteArray, ref p);

            ClassId = new FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId();
            ClassId.Decode(byteArray, ref p);

            Attribute = new FinalBiome.Api.Types.PalletSupport.Attribute();
            Attribute.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
