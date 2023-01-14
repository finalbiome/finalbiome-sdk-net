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
namespace FinalBiome.Api.Types.FrameSystem.Pallet
{
    /// <summary>
    /// Error for the System pallet<br/>
    ///
    ///
    /// Generated from meta with Type Id 94
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// The name of specification does not match between the current runtime<br/>
    /// and the new runtime.<br/>
    /// </summary>
        InvalidSpecName = 0,
    /// <summary>
    /// The specification version is not allowed to decrease between the current runtime<br/>
    /// and the new runtime.<br/>
    /// </summary>
        SpecVersionNeedsToIncrease = 1,
    /// <summary>
    /// Failed to extract the runtime version from the new runtime.<br/>
    /// <para></para>
    /// Either calling `Core_version` or decoding `RuntimeVersion` failed.<br/>
    /// </summary>
        FailedToExtractRuntimeVersion = 2,
    /// <summary>
    /// Suicide called when the account has non-default composite data.<br/>
    /// </summary>
        NonDefaultComposite = 3,
    /// <summary>
    /// There is a non-zero reference count preventing the account from being purged.<br/>
    /// </summary>
        NonZeroRefCount = 4,
    /// <summary>
    /// The origin filter prevent the call to be dispatched.<br/>
    /// </summary>
        CallFiltered = 5,
    }
    /// <summary>
    /// Error for the System pallet<br/>
    ///
    ///
    /// Generated from meta with Type Id 94
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
