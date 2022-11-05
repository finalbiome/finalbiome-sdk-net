///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
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
        /// # <weight><br/>
        /// - `O(1)` (Note that implementations of `OnTimestampSet` must also be `O(1)`)<br/>
        /// - 1 storage read and 1 storage mutation (codec `O(1)`). (because of `DidUpdate::take` in<br/>
        ///   `on_finalize`)<br/>
        /// - 1 event handler `on_timestamp_set`. Must be `O(1)`.<br/>
        /// # </weight><br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> Set(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.CompactU64 now, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.CompactU64> data = new BaseTuple<FinalBiome.Sdk.CompactU64>();
            data.Create(now);
            byte[] parameters = data.Encode();
            Method method = new Method(2, 0, parameters);
            ChargeType charge = ChargeTransactionPayment.Default();
            uint lifeTime = 0;
            token = CancellationToken.None;
            
            if (subscription is null)
            {
                await _client.client.Author.SubmitExtrinsicAsync(method, account, charge, lifeTime, (CancellationToken)token);
                return null;
            }
            else
            {
                string subscriptionId = await _client.client.Author.SubmitAndWatchExtrinsicAsync(subscription, method, account, charge, lifeTime, (CancellationToken)token);
                return subscriptionId;
            }
        }
    }
}
