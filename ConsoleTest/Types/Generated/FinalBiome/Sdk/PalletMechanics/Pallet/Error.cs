///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Pallet
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
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
