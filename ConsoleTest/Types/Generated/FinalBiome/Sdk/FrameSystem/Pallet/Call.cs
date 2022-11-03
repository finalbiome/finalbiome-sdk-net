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
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 68
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// A dispatch that will fill the block weight up to the given ratio.
    /// </summary>
        fill_block,
    /// <summary>
    /// Make some on-chain remark.
    /// 
    /// # <weight>
    /// - `O(1)`
    /// # </weight>
    /// </summary>
        remark,
    /// <summary>
    /// Set the number of pages in the WebAssembly environment's heap.
    /// </summary>
        set_heap_pages,
    /// <summary>
    /// Set the new runtime code.
    /// 
    /// # <weight>
    /// - `O(C + S)` where `C` length of `code` and `S` complexity of `can_set_code`
    /// - 1 call to `can_set_code`: `O(S)` (calls `sp_io::misc::runtime_version` which is
    ///   expensive).
    /// - 1 storage write (codec `O(C)`).
    /// - 1 digest item.
    /// - 1 event.
    /// The weight of this function is dependent on the runtime, but generally this is very
    /// expensive. We will treat this as a full block.
    /// # </weight>
    /// </summary>
        set_code,
    /// <summary>
    /// Set the new runtime code without doing any checks of the given `code`.
    /// 
    /// # <weight>
    /// - `O(C)` where `C` length of `code`
    /// - 1 storage write (codec `O(C)`).
    /// - 1 digest item.
    /// - 1 event.
    /// The weight of this function is dependent on the runtime. We will treat this as a full
    /// block. # </weight>
    /// </summary>
        set_code_without_checks,
    /// <summary>
    /// Set some items of storage.
    /// </summary>
        set_storage,
    /// <summary>
    /// Kill some items from storage.
    /// </summary>
        kill_storage,
    /// <summary>
    /// Kill all storage items with a key that starts with the given prefix.
    /// 
    /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under
    /// the prefix we are removing to accurately calculate the weight of this function.
    /// </summary>
        kill_prefix,
    /// <summary>
    /// Make some on-chain remark and emit event.
    /// </summary>
        remark_with_event,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 68
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.SpArithmetic.PerThings.Perbill, FinalBiome.Sdk.VecU8, Ajuna.NetApi.Model.Types.Primitive.U64, FinalBiome.Sdk.VecU8, FinalBiome.Sdk.VecU8, FinalBiome.Sdk.Model.Types.Base.VecTuple_VecU8_VecU8, FinalBiome.Sdk.VecVecU8, BaseTuple<FinalBiome.Sdk.VecU8, Ajuna.NetApi.Model.Types.Primitive.U32>, FinalBiome.Sdk.VecU8>
    {
        public override string TypeName() => "Call";
    }
}
