///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport.Characteristics.Bettor
{
    /// <summary>
    /// Generated from meta with Type Id 162
    /// </summary>
    public enum InnerBettorWinning : byte
    {
        Fa = 0,
        Nfa = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 162
    /// </summary>
    public class BettorWinning : Enum<InnerBettorWinning, Tuple<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId>
    {
        public override string TypeName() => "BettorWinning";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
