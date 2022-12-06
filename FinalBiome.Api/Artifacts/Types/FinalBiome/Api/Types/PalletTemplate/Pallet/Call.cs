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
namespace FinalBiome.Api.Types.PalletTemplate.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 130
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// An example dispatchable that takes a singles value as a parameter, writes the value to<br/>
    /// storage and emits an event. This function must be dispatched by a signed extrinsic.<br/>
    /// </summary>
        do_something = 0,
    /// <summary>
    /// An example dispatchable that may throw a custom error.<br/>
    /// </summary>
        cause_error = 1,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 130
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletTemplate.Pallet.CallDoSomething, BaseVoid>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
