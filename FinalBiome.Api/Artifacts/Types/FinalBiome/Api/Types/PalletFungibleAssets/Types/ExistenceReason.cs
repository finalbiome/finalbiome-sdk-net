///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletFungibleAssets.Types
{
    /// <summary>
    /// Generated from meta with Type Id 176
    /// </summary>
    public enum InnerExistenceReason : byte
    {
        Consumer = 0,
        Sufficient = 1,
        DepositHeld = 2,
        DepositRefunded = 3,
    }
    /// <summary>
    /// Generated from meta with Type Id 176
    /// </summary>
    public class ExistenceReason : Enum<InnerExistenceReason, BaseVoid, BaseVoid, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance, BaseVoid>
    {
        public override string TypeName() => "ExistenceReason";
    }
}
