///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletMechanics.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 52
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
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 52
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletMechanics.Pallet.EventFinished, FinalBiome.Api.Types.PalletMechanics.Pallet.EventStopped>
    {
        public override string TypeName() => "Event";
    }
}
