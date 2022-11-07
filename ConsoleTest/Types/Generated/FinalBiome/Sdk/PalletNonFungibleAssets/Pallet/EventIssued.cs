///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    /// An asset `instance` has been issued.<br/>
    ///
    ///
    /// Generated from meta with Type Id 44, Variant Id 3
    /// </summary>
    public class EventIssued : BaseType
    {
        public override string TypeName() => "EventIssued";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId ClassId { get; private set; }
        public FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId AssetId { get; private set; }
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Owner { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ClassId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId();
            ClassId.Decode(byteArray, ref p);

            AssetId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId();
            AssetId.Decode(byteArray, ref p);

            Owner = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
