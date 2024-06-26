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
namespace FinalBiome.Api.Types.FrameSystem.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 76
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// A dispatch that will fill the block weight up to the given ratio.<br/>
    /// </summary>
        fill_block = 0,
    /// <summary>
    /// Make some on-chain remark.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - `O(1)`<br/>
    /// # &lt;/weight&gt;<br/>
    /// </summary>
        remark = 1,
    /// <summary>
    /// Set the number of pages in the WebAssembly environment's heap.<br/>
    /// </summary>
        set_heap_pages = 2,
    /// <summary>
    /// Set the new runtime code.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - `O(C + S)` where `C` length of `code` and `S` complexity of `can_set_code`<br/>
    /// - 1 call to `can_set_code`: `O(S)` (calls `sp_io::misc::runtime_version` which is<br/>
    ///   expensive).<br/>
    /// - 1 storage write (codec `O(C)`).<br/>
    /// - 1 digest item.<br/>
    /// - 1 event.<br/>
    /// The weight of this function is dependent on the runtime, but generally this is very<br/>
    /// expensive. We will treat this as a full block.<br/>
    /// # &lt;/weight&gt;<br/>
    /// </summary>
        set_code = 3,
    /// <summary>
    /// Set the new runtime code without doing any checks of the given `code`.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - `O(C)` where `C` length of `code`<br/>
    /// - 1 storage write (codec `O(C)`).<br/>
    /// - 1 digest item.<br/>
    /// - 1 event.<br/>
    /// The weight of this function is dependent on the runtime. We will treat this as a full<br/>
    /// block. # &lt;/weight&gt;<br/>
    /// </summary>
        set_code_without_checks = 4,
    /// <summary>
    /// Set some items of storage.<br/>
    /// </summary>
        set_storage = 5,
    /// <summary>
    /// Kill some items from storage.<br/>
    /// </summary>
        kill_storage = 6,
    /// <summary>
    /// Kill all storage items with a key that starts with the given prefix.<br/>
    /// <para></para>
    /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under<br/>
    /// the prefix we are removing to accurately calculate the weight of this function.<br/>
    /// </summary>
        kill_prefix = 7,
    /// <summary>
    /// Make some on-chain remark and emit event.<br/>
    /// </summary>
        remark_with_event = 8,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 76
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.FrameSystem.Pallet.CallFillBlock, FinalBiome.Api.Types.FrameSystem.Pallet.CallRemark, FinalBiome.Api.Types.FrameSystem.Pallet.CallSetHeapPages, FinalBiome.Api.Types.FrameSystem.Pallet.CallSetCode, FinalBiome.Api.Types.FrameSystem.Pallet.CallSetCodeWithoutChecks, FinalBiome.Api.Types.FrameSystem.Pallet.CallSetStorage, FinalBiome.Api.Types.FrameSystem.Pallet.CallKillStorage, FinalBiome.Api.Types.FrameSystem.Pallet.CallKillPrefix, FinalBiome.Api.Types.FrameSystem.Pallet.CallRemarkWithEvent>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
