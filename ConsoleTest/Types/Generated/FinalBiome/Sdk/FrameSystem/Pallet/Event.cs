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
    /// Event for the System pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// An extrinsic completed successfully.<br/>
    /// </summary>
        ExtrinsicSuccess,
    /// <summary>
    /// An extrinsic failed.<br/>
    /// </summary>
        ExtrinsicFailed,
    /// <summary>
    /// `:code` was updated.<br/>
    /// </summary>
        CodeUpdated,
    /// <summary>
    /// A new account was created.<br/>
    /// </summary>
        NewAccount,
    /// <summary>
    /// An account was reaped.<br/>
    /// </summary>
        KilledAccount,
    /// <summary>
    /// On on-chain remark happened.<br/>
    /// </summary>
        Remarked,
    }
    /// <summary>
    /// Event for the System pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.FrameSystem.Pallet.EventExtrinsicSuccess, FinalBiome.Sdk.FrameSystem.Pallet.EventExtrinsicFailed, BaseVoid, FinalBiome.Sdk.FrameSystem.Pallet.EventNewAccount, FinalBiome.Sdk.FrameSystem.Pallet.EventKilledAccount, FinalBiome.Sdk.FrameSystem.Pallet.EventRemarked>
    {
        public override string TypeName() => "Event";
    }
}
