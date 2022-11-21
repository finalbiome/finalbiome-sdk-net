///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletFungibleAssets.Pallet
{
    /// <summary>
    /// Destroy a fungible asset.<br/>
    /// <para></para>
    /// The origin must be Signed and must be a member of the organization<br/>
    ///
    ///
    /// Generated from meta with Type Id 139, Variant Id 1
    /// </summary>
    public class CallDestroy : Codec
    {
        public override string TypeName() => "CallDestroy";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress OrganizationId { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.CompactFungibleAssetId AssetId { get; private set; }
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

            AssetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.CompactFungibleAssetId();
            AssetId.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}