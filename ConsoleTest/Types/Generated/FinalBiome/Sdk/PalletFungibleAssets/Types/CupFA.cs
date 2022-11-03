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
    /// Generated from meta with Type Id 143
    /// </summary>
    public class CupFA : BaseType
    {
        public override string TypeName() => "CupFA";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Amount { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Amount = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Amount.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
