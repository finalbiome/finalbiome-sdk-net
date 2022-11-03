///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletFungibleAssets.Types
{
    /// <summary>
    /// Generated from meta with Type Id 176
    /// </summary>
    public enum InnerExistenceReason
    {
        Consumer,
        Sufficient,
        DepositHeld,
        DepositRefunded,
    }
    /// <summary>
    /// Generated from meta with Type Id 176
    /// </summary>
    public class ExistenceReason : BaseEnumExt<InnerExistenceReason, BaseVoid, BaseVoid, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance, BaseVoid>
    {
        public override string TypeName() => "ExistenceReason";
    }
}
