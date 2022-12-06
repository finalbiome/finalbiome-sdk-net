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
    /// Event for the System pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// An extrinsic completed successfully.<br/>
    /// </summary>
        ExtrinsicSuccess = 0,
    /// <summary>
    /// An extrinsic failed.<br/>
    /// </summary>
        ExtrinsicFailed = 1,
    /// <summary>
    /// `:code` was updated.<br/>
    /// </summary>
        CodeUpdated = 2,
    /// <summary>
    /// A new account was created.<br/>
    /// </summary>
        NewAccount = 3,
    /// <summary>
    /// An account was reaped.<br/>
    /// </summary>
        KilledAccount = 4,
    /// <summary>
    /// On on-chain remark happened.<br/>
    /// </summary>
        Remarked = 5,
    }
    /// <summary>
    /// Event for the System pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.FrameSystem.Pallet.EventExtrinsicSuccess, FinalBiome.Api.Types.FrameSystem.Pallet.EventExtrinsicFailed, BaseVoid, FinalBiome.Api.Types.FrameSystem.Pallet.EventNewAccount, FinalBiome.Api.Types.FrameSystem.Pallet.EventKilledAccount, FinalBiome.Api.Types.FrameSystem.Pallet.EventRemarked>
    {
        public override string TypeName() => "Event";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
