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
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 53
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// Mechanics done.<br/>
    /// </summary>
        Finished = 0,
    /// <summary>
    /// Mechanics was stopped.<br/>
    /// </summary>
        Stopped = 1,
    /// <summary>
    /// Mechanics as dropped by typeout.<br/>
    /// </summary>
        DroppedByTimeout = 2,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 53
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletMechanics.Pallet.EventFinished, FinalBiome.Api.Types.PalletMechanics.Pallet.EventStopped, FinalBiome.Api.Types.PalletMechanics.Pallet.EventDroppedByTimeout>
    {
        public override string TypeName() => "Event";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
