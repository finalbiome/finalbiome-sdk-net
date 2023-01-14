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
namespace FinalBiome.Api.Types.PalletFungibleAssets.Types
{
    /// <summary>
    /// Generated from meta with Type Id 188
    /// </summary>
    public enum InnerExistenceReason : byte
    {
        Consumer = 0,
        Sufficient = 1,
        DepositHeld = 2,
        DepositRefunded = 3,
    }
    /// <summary>
    /// Generated from meta with Type Id 188
    /// </summary>
    public class ExistenceReason : Enum<InnerExistenceReason, BaseVoid, BaseVoid, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance, BaseVoid>
    {
        public override string TypeName() => "ExistenceReason";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
