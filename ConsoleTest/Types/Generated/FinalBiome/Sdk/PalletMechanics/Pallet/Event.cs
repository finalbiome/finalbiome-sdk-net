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
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.PalletMechanics.Pallet.EventFinished, FinalBiome.Sdk.PalletMechanics.Pallet.EventStopped>
    {
        public override string TypeName() => "Event";
    }
}
