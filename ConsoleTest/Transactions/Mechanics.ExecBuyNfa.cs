///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class Mechanics
    {
        /// <summary>
        /// Execute mechanic `Buy NFA`<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> ExecBuyNfa(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId classId, Ajuna.NetApi.Model.Types.Primitive.U32 offerId, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, Ajuna.NetApi.Model.Types.Primitive.U32> data = new BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, Ajuna.NetApi.Model.Types.Primitive.U32>();
            data.Create(classId, offerId);
            byte[] parameters = data.Encode();
            Method method = new Method(12, 0, parameters);
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
