///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSudo.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 35
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// A sudo just took place. \[result\]<br/>
    /// </summary>
        Sudid = 0,
    /// <summary>
    /// The \[sudoer\] just switched identity; the old key is supplied if one existed.<br/>
    /// </summary>
        KeyChanged = 1,
    /// <summary>
    /// A sudo just took place. \[result\]<br/>
    /// </summary>
        SudoAsDone = 2,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 35
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletSudo.Pallet.EventSudid, FinalBiome.Api.Types.PalletSudo.Pallet.EventKeyChanged, FinalBiome.Api.Types.PalletSudo.Pallet.EventSudoAsDone>
    {
        public override string TypeName() => "Event";
    }
}
