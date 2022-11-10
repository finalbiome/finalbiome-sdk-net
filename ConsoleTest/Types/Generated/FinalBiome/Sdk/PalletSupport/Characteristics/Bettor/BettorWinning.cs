///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport.Characteristics.Bettor
{
    /// <summary>
    /// Generated from meta with Type Id 155
    /// </summary>
    public enum InnerBettorWinning : byte
    {
        Fa = 0,
        Nfa = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 155
    /// </summary>
    public class BettorWinning : BaseEnumExt<InnerBettorWinning, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId>
    {
        public override string TypeName() => "BettorWinning";
    }
}
