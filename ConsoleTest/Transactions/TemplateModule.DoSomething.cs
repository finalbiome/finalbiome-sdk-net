///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class TemplateModule
    {
        /// <summary>
        /// An example dispatchable that takes a singles value as a parameter, writes the value to<br/>
        /// storage and emits an event. This function must be dispatched by a signed extrinsic.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> DoSomething(Ajuna.NetApi.Model.Types.Account account, Ajuna.NetApi.Model.Types.Primitive.U32 something, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32> data = new BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32>();
            data.Create(something);
            byte[] parameters = data.Encode();
            Method method = new Method(8, 0, parameters);
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
