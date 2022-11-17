///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport.Characteristics.Bettor
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
    public class BettorWinning : Enum<InnerBettorWinning, Tuple<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId>
    {
        public override string TypeName() => "BettorWinning";
    }
}
