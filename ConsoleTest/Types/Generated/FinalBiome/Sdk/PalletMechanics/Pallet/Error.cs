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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 199
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Mechanics are not available for this asset or this origin
    /// </summary>
        MechanicsNotAvailable,
    /// <summary>
    /// Internal error
    /// </summary>
        Internal,
    /// <summary>
    /// The number of assets exceeds the allowable
    /// </summary>
        AssetsExceedsAllowable,
    /// <summary>
    /// Asset is incompatible with mechanic
    /// </summary>
        IncompatibleAsset,
    /// <summary>
    /// Given data is incompatible with mechanic
    /// </summary>
        IncompatibleData,
    /// <summary>
    /// The signing account has no permission to do the operation.
    /// </summary>
        NoPermission,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 199
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
