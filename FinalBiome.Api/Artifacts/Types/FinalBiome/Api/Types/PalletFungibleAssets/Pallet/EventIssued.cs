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
namespace FinalBiome.Api.Types.PalletFungibleAssets.Pallet
{
    /// <summary>
    /// Some assets were issued.<br/>
    ///
    ///
    /// Generated from meta with Type Id 42, Variant Id 1
    /// </summary>
    public class EventIssued : Codec
    {
        public override string TypeName() => "EventIssued";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId AssetId { get; private set; }
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance TotalSupply { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            AssetId = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
            AssetId.Decode(byteArray, ref p);

            Owner = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            TotalSupply = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            TotalSupply.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
