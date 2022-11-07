///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// A dispatch that will fill the block weight up to the given ratio.<br/>
    /// </summary>
        fill_block,
    /// <summary>
    /// Make some on-chain remark.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - `O(1)`<br/>
    /// # </weight><br/>
    /// </summary>
        remark,
    /// <summary>
    /// Set the number of pages in the WebAssembly environment's heap.<br/>
    /// </summary>
        set_heap_pages,
    /// <summary>
    /// Set the new runtime code.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - `O(C + S)` where `C` length of `code` and `S` complexity of `can_set_code`<br/>
    /// - 1 call to `can_set_code`: `O(S)` (calls `sp_io::misc::runtime_version` which is<br/>
    ///   expensive).<br/>
    /// - 1 storage write (codec `O(C)`).<br/>
    /// - 1 digest item.<br/>
    /// - 1 event.<br/>
    /// The weight of this function is dependent on the runtime, but generally this is very<br/>
    /// expensive. We will treat this as a full block.<br/>
    /// # </weight><br/>
    /// </summary>
        set_code,
    /// <summary>
    /// Set the new runtime code without doing any checks of the given `code`.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - `O(C)` where `C` length of `code`<br/>
    /// - 1 storage write (codec `O(C)`).<br/>
    /// - 1 digest item.<br/>
    /// - 1 event.<br/>
    /// The weight of this function is dependent on the runtime. We will treat this as a full<br/>
    /// block. # </weight><br/>
    /// </summary>
        set_code_without_checks,
    /// <summary>
    /// Set some items of storage.<br/>
    /// </summary>
        set_storage,
    /// <summary>
    /// Kill some items from storage.<br/>
    /// </summary>
        kill_storage,
    /// <summary>
    /// Kill all storage items with a key that starts with the given prefix.<br/>
    /// <para></para>
    /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under<br/>
    /// the prefix we are removing to accurately calculate the weight of this function.<br/>
    /// </summary>
        kill_prefix,
    /// <summary>
    /// Make some on-chain remark and emit event.<br/>
    /// </summary>
        remark_with_event,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.FrameSystem.Pallet.CallFillBlock, FinalBiome.Sdk.FrameSystem.Pallet.CallRemark, FinalBiome.Sdk.FrameSystem.Pallet.CallSetHeapPages, FinalBiome.Sdk.FrameSystem.Pallet.CallSetCode, FinalBiome.Sdk.FrameSystem.Pallet.CallSetCodeWithoutChecks, FinalBiome.Sdk.FrameSystem.Pallet.CallSetStorage, FinalBiome.Sdk.FrameSystem.Pallet.CallKillStorage, FinalBiome.Sdk.FrameSystem.Pallet.CallKillPrefix, FinalBiome.Sdk.FrameSystem.Pallet.CallRemarkWithEvent>
    {
        public override string TypeName() => "Call";
    }
}
