///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletTemplate.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 130
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// An example dispatchable that takes a singles value as a parameter, writes the value to<br/>
    /// storage and emits an event. This function must be dispatched by a signed extrinsic.<br/>
    /// </summary>
        do_something,
    /// <summary>
    /// An example dispatchable that may throw a custom error.<br/>
    /// </summary>
        cause_error,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 130
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.PalletTemplate.Pallet.CallDoSomething, BaseVoid>
    {
        public override string TypeName() => "Call";
    }
}
