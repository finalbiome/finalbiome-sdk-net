///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class Grandpa
    {
        /// <summary>
        /// Note that the current authority set of the GRANDPA finality gadget has stalled.<br/>
        /// <para></para>
        /// This will trigger a forced authority set change at the beginning of the next session, to<br/>
        /// be enacted `delay` blocks after that. The `delay` should be high enough to safely assume<br/>
        /// that the block signalling the forced change will not be re-orged e.g. 1000 blocks.<br/>
        /// The block production rate (which may be slowed down because of finality lagging) should<br/>
        /// be taken into account when choosing the `delay`. The GRANDPA voters based on the new<br/>
        /// authority will start voting on top of `best_finalized_block_number` for new finalized<br/>
        /// blocks. `best_finalized_block_number` should be the highest of the latest finalized<br/>
        /// block of all validators of the new authority set.<br/>
        /// <para></para>
        /// Only callable by root.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> NoteStalled(Ajuna.NetApi.Model.Types.Account account, Ajuna.NetApi.Model.Types.Primitive.U32 delay, Ajuna.NetApi.Model.Types.Primitive.U32 bestFinalizedBlockNumber, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32> data = new BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>();
            data.Create(delay, bestFinalizedBlockNumber);
            byte[] parameters = data.Encode();
            Method method = new Method(4, 2, parameters);
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
