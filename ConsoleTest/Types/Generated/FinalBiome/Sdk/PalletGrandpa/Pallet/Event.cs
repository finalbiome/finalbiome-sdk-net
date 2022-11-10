///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletGrandpa.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 27
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// New authority set has been applied.<br/>
    /// </summary>
        NewAuthorities = 0,
    /// <summary>
    /// Current authority set has been paused.<br/>
    /// </summary>
        Paused = 1,
    /// <summary>
    /// Current authority set has been resumed.<br/>
    /// </summary>
        Resumed = 2,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 27
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.PalletGrandpa.Pallet.EventNewAuthorities, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Event";
    }
}
