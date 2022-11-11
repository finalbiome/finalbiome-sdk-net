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
        /// This function does not check the weight of the call, and instead allows the<br/>
        /// Sudo user to specify the weight of the call.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be _Signed_.<br/>
        /// <para></para>
        /// # <weight><br/>
        /// - O(1).<br/>
        /// - The weight of this call is defined by the caller.<br/>
        /// # </weight><br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> SudoUncheckedWeight(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.FinalbiomeNodeRuntime.Call call, Ajuna.NetApi.Model.Types.Primitive.U64 weight, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.FinalbiomeNodeRuntime.Call, Ajuna.NetApi.Model.Types.Primitive.U64> data = new BaseTuple<FinalBiome.Sdk.FinalbiomeNodeRuntime.Call, Ajuna.NetApi.Model.Types.Primitive.U64>();
            data.Create(call, weight);
            byte[] parameters = data.Encode();
            Method method = new Method(7, 1, parameters);
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
