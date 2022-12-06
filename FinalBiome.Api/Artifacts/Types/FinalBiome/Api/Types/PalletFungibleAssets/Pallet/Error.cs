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
namespace FinalBiome.Api.Types.PalletFungibleAssets.Pallet
{
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// Error names should be descriptive.<br/>
    /// </summary>
        NoneValue = 0,
    /// <summary>
    /// Errors should have helpful documentation associated with them.<br/>
    /// </summary>
        StorageOverflow = 1,
    /// <summary>
    /// The asset ID is already taken.<br/>
    /// </summary>
        InUse = 2,
        NoAvailableAssetId = 3,
    /// <summary>
    /// The signing account has no permission to do the operation.<br/>
    /// </summary>
        NoPermission = 4,
    /// <summary>
    /// Asset name is too long.<br/>
    /// </summary>
        AssetNameTooLong = 5,
    /// <summary>
    /// Limit of tipupped assets is reached.<br/>
    /// </summary>
        MaxTopUppedAssetsReached = 6,
    /// <summary>
    /// Global Cup must be above zero.<br/>
    /// </summary>
        ZeroGlobalCup = 7,
    /// <summary>
    /// Local Cup must be above zero.<br/>
    /// </summary>
        ZeroLocalCup = 8,
    /// <summary>
    /// Top upped speed must be above zero.<br/>
    /// </summary>
        ZeroTopUpped = 9,
    /// <summary>
    /// Top upped speed can't be set without a local cup.<br/>
    /// </summary>
        TopUppedWithNoCup = 10,
    /// <summary>
    /// The account to alter does not exist.<br/>
    /// </summary>
        NoAccount = 11,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public class Error : Enum<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
