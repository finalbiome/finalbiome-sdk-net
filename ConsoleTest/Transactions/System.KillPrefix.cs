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
        /// Kill all storage items with a key that starts with the given prefix.<br/>
        /// <para></para>
        /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under<br/>
        /// the prefix we are removing to accurately calculate the weight of this function.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> KillPrefix(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.VecU8 prefix, Ajuna.NetApi.Model.Types.Primitive.U32 subkeys, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.VecU8, Ajuna.NetApi.Model.Types.Primitive.U32> data = new BaseTuple<FinalBiome.Sdk.VecU8, Ajuna.NetApi.Model.Types.Primitive.U32>();
            data.Create(prefix, subkeys);
            byte[] parameters = data.Encode();
            Method method = new Method(0, 7, parameters);
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
