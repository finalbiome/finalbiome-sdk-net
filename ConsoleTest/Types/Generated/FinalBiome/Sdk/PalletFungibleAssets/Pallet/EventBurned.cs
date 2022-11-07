///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletFungibleAssets.Pallet
{
    /// <summary>
    /// Some assets were destroyed.<br/>
    ///
    ///
    /// Generated from meta with Type Id 41, Variant Id 2
    /// </summary>
    public class EventBurned : BaseType
    {
        public override string TypeName() => "EventBurned";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId AssetId { get; private set; }
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Balance { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            AssetId = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
            AssetId.Decode(byteArray, ref p);

            Owner = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            Balance = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Balance.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}