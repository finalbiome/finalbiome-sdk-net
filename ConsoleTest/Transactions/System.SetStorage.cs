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
        /// Set some items of storage.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> SetStorage(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.Model.Types.Base.VecTuple_VecU8_VecU8 items, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.Model.Types.Base.VecTuple_VecU8_VecU8> data = new BaseTuple<FinalBiome.Sdk.Model.Types.Base.VecTuple_VecU8_VecU8>();
            data.Create(items);
            byte[] parameters = data.Encode();
            Method method = new Method(0, 5, parameters);
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
