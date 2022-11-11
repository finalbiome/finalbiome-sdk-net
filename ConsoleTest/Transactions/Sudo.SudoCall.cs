///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class Sudo
    {
        /// <summary>
        /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be _Signed_.<br/>
        /// <para></para>
        /// # <weight><br/>
        /// - O(1).<br/>
        /// - Limited storage reads.<br/>
        /// - One DB write (event).<br/>
        /// - Weight of derivative `call` execution + 10,000.<br/>
        /// # </weight><br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> SudoCall(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.FinalbiomeNodeRuntime.Call call, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.FinalbiomeNodeRuntime.Call> data = new BaseTuple<FinalBiome.Sdk.FinalbiomeNodeRuntime.Call>();
            data.Create(call);
            byte[] parameters = data.Encode();
            Method method = new Method(7, 0, parameters);
            ChargeType charge = ChargeTransactionPayment.Default();
            uint lifeTime = 0;
            token = CancellationToken.None;
            
            if (subscription is null)
            {
                return (await _client.client.Author.SubmitExtrinsicAsync(method, account, charge, lifeTime, (CancellationToken)token)).Value;
            }
            else
            {
                string subscriptionId = await _client.client.Author.SubmitAndWatchExtrinsicAsync(subscription, method, account, charge, lifeTime, (CancellationToken)token);
                return subscriptionId;
            }
        }
    }
}
