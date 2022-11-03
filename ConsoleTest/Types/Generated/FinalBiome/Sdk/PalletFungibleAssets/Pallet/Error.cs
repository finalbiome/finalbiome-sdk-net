///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletFungibleAssets.Pallet
{
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Error names should be descriptive.
    /// </summary>
        NoneValue,
    /// <summary>
    /// Errors should have helpful documentation associated with them.
    /// </summary>
        StorageOverflow,
    /// <summary>
    /// The asset ID is already taken.
    /// </summary>
        InUse,
        NoAvailableAssetId,
    /// <summary>
    /// The signing account has no permission to do the operation.
    /// </summary>
        NoPermission,
    /// <summary>
    /// Asset name is too long.
    /// </summary>
        AssetNameTooLong,
    /// <summary>
    /// Limit of tipupped assets is reached.
    /// </summary>
        MaxTopUppedAssetsReached,
    /// <summary>
    /// Global Cup must be above zero.
    /// </summary>
        ZeroGlobalCup,
    /// <summary>
    /// Local Cup must be above zero.
    /// </summary>
        ZeroLocalCup,
    /// <summary>
    /// Top upped speed must be above zero.
    /// </summary>
        ZeroTopUpped,
    /// <summary>
    /// Top upped speed can't be set without a local cup.
    /// </summary>
        TopUppedWithNoCup,
    /// <summary>
    /// The account to alter does not exist.
    /// </summary>
        NoAccount,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
