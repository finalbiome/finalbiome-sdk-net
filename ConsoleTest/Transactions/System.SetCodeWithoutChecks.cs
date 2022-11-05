///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class System
    {
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
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> SetCodeWithoutChecks(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.VecU8 code, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.VecU8> data = new BaseTuple<FinalBiome.Sdk.VecU8>();
            data.Create(code);
            byte[] parameters = data.Encode();
            Method method = new Method(0, 4, parameters);
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
