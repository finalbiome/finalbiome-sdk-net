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
        /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo<br/>
        /// key.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be _Signed_.<br/>
        /// <para></para>
        /// # <weight><br/>
        /// - O(1).<br/>
        /// - Limited storage reads.<br/>
        /// - One DB change.<br/>
        /// # </weight><br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> SetKey(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress _new, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress>();
            data.Create(_new);
            byte[] parameters = data.Encode();
            Method method = new Method(7, 2, parameters);
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
