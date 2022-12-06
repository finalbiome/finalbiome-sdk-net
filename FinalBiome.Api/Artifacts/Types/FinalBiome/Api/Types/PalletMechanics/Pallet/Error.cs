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
namespace FinalBiome.Api.Types.PalletMechanics.Pallet
{
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 199
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// Mechanics are not available for this asset or this origin<br/>
    /// </summary>
        MechanicsNotAvailable = 0,
    /// <summary>
    /// Internal error<br/>
    /// </summary>
        Internal = 1,
    /// <summary>
    /// The number of assets exceeds the allowable<br/>
    /// </summary>
        AssetsExceedsAllowable = 2,
    /// <summary>
    /// Asset is incompatible with mechanic<br/>
    /// </summary>
        IncompatibleAsset = 3,
    /// <summary>
    /// Given data is incompatible with mechanic<br/>
    /// </summary>
        IncompatibleData = 4,
    /// <summary>
    /// The signing account has no permission to do the operation.<br/>
    /// </summary>
        NoPermission = 5,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 199
    /// </summary>
    public class Error : Enum<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
