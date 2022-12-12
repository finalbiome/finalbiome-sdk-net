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
namespace FinalBiome.Api.Types.PalletGrandpa.Pallet
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
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletGrandpa.Pallet.EventNewAuthorities, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Event";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
