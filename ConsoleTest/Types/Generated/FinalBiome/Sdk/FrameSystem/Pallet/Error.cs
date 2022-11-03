///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Pallet
{
    /// <summary>
    /// Error for the System pallet
    ///
    ///
    /// Generated from meta with Type Id 86
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// The name of specification does not match between the current runtime
    /// and the new runtime.
    /// </summary>
        InvalidSpecName,
    /// <summary>
    /// The specification version is not allowed to decrease between the current runtime
    /// and the new runtime.
    /// </summary>
        SpecVersionNeedsToIncrease,
    /// <summary>
    /// Failed to extract the runtime version from the new runtime.
    /// 
    /// Either calling `Core_version` or decoding `RuntimeVersion` failed.
    /// </summary>
        FailedToExtractRuntimeVersion,
    /// <summary>
    /// Suicide called when the account has non-default composite data.
    /// </summary>
        NonDefaultComposite,
    /// <summary>
    /// There is a non-zero reference count preventing the account from being purged.
    /// </summary>
        NonZeroRefCount,
    /// <summary>
    /// The origin filter prevent the call to be dispatched.
    /// </summary>
        CallFiltered,
    }
    /// <summary>
    /// Error for the System pallet
    ///
    ///
    /// Generated from meta with Type Id 86
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
