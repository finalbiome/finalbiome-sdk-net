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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Error names should be descriptive.<br/>
    /// </summary>
        NoneValue,
    /// <summary>
    /// Errors should have helpful documentation associated with them.<br/>
    /// </summary>
        StorageOverflow,
    /// <summary>
    /// The asset ID is already taken.<br/>
    /// </summary>
        InUse,
        NoAvailableAssetId,
    /// <summary>
    /// The signing account has no permission to do the operation.<br/>
    /// </summary>
        NoPermission,
    /// <summary>
    /// Asset name is too long.<br/>
    /// </summary>
        AssetNameTooLong,
    /// <summary>
    /// Limit of tipupped assets is reached.<br/>
    /// </summary>
        MaxTopUppedAssetsReached,
    /// <summary>
    /// Global Cup must be above zero.<br/>
    /// </summary>
        ZeroGlobalCup,
    /// <summary>
    /// Local Cup must be above zero.<br/>
    /// </summary>
        ZeroLocalCup,
    /// <summary>
    /// Top upped speed must be above zero.<br/>
    /// </summary>
        ZeroTopUpped,
    /// <summary>
    /// Top upped speed can't be set without a local cup.<br/>
    /// </summary>
        TopUppedWithNoCup,
    /// <summary>
    /// The account to alter does not exist.<br/>
    /// </summary>
        NoAccount,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
