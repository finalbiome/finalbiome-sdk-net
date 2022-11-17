///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport
{
    /// <summary>
    /// Generated from meta with Type Id 194
    /// </summary>
    public enum InnerLockedAccet : byte
    {
        Fa = 0,
        Nfa = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 194
    /// </summary>
    public class LockedAccet : Enum<InnerLockedAccet, Tuple<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, Tuple<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId>>
    {
        public override string TypeName() => "LockedAccet";
    }
}
