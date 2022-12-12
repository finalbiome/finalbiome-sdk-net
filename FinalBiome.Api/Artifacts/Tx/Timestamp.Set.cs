///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Tx
{
    public partial class Timestamp
    {
        /// <summary>
        /// Set the current time.<br/>
        /// <para></para>
        /// This call should be invoked exactly once per block. It will panic at the finalization<br/>
        /// phase, if this call hasn't been invoked by that time.<br/>
        /// <para></para>
        /// The timestamp should be greater than the previous one by the amount specified by<br/>
        /// `MinimumPeriod`.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be `Inherent`.<br/>
        /// <para></para>
        /// # &lt;weight&gt;<br/>
        /// - `O(1)` (Note that implementations of `OnTimestampSet` must also be `O(1)`)<br/>
        /// - 1 storage read and 1 storage mutation (codec `O(1)`). (because of `DidUpdate::take` in<br/>
        ///   `on_finalize`)<br/>
        /// - 1 event handler `on_timestamp_set`. Must be `O(1)`.<br/>
        /// # &lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload Set(FinalBiome.Api.Types.CompactU64 now)
        {
            byte palletIsx = 2;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            now.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
