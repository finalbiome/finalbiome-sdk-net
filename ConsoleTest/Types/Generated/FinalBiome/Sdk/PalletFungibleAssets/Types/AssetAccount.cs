///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletFungibleAssets.Types
{
    /// <summary>
    /// Generated from meta with Type Id 175
    /// </summary>
    public class AssetAccount : BaseType
    {
        public override string TypeName() => "AssetAccount";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Balance { get; private set; }
        public FinalBiome.Sdk.PalletFungibleAssets.Types.ExistenceReason Reason { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Balance = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Balance.Decode(byteArray, ref p);

            Reason = new FinalBiome.Sdk.PalletFungibleAssets.Types.ExistenceReason();
            Reason.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
