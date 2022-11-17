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
    /// Some assets were destroyed.<br/>
    ///
    ///
    /// Generated from meta with Type Id 41, Variant Id 2
    /// </summary>
    public class EventBurned : Codec
    {
        public override string TypeName() => "EventBurned";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId AssetId { get; private set; }
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Balance { get; private set; }
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

            Balance = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Balance.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
