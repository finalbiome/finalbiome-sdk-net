///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletTimestamp.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 88
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Set the current time.
    /// 
    /// This call should be invoked exactly once per block. It will panic at the finalization
    /// phase, if this call hasn't been invoked by that time.
    /// 
    /// The timestamp should be greater than the previous one by the amount specified by
    /// `MinimumPeriod`.
    /// 
    /// The dispatch origin for this call must be `Inherent`.
    /// 
    /// # <weight>
    /// - `O(1)` (Note that implementations of `OnTimestampSet` must also be `O(1)`)
    /// - 1 storage read and 1 storage mutation (codec `O(1)`). (because of `DidUpdate::take` in
    ///   `on_finalize`)
    /// - 1 event handler `on_timestamp_set`. Must be `O(1)`.
    /// # </weight>
    /// </summary>
        set,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 88
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.CompactU64>
    {
        public override string TypeName() => "Call";
    }
}
