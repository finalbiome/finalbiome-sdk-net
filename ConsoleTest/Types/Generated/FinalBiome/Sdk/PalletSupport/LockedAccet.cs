///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport
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
    public class LockedAccet : BaseEnumExt<InnerLockedAccet, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId>>
    {
        public override string TypeName() => "LockedAccet";
    }
}
