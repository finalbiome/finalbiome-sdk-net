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
namespace FinalBiome.Api.Types.PalletUsers.Pallet
{
    /// <summary>
    /// Events of the Users pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 40
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// The \[Registrar\] just switched identity; the old key is supplied if one existed.<br/>
    /// </summary>
        KeyChanged = 0,
    }
    /// <summary>
    /// Events of the Users pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 40
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletUsers.Pallet.EventKeyChanged>
    {
        public override string TypeName() => "Event";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
