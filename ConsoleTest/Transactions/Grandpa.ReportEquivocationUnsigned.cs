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
        /// Report voter equivocation/misbehavior. This method will verify the<br/>
        /// equivocation proof and validate the given key ownership proof<br/>
        /// against the extracted offender. If both are valid, the offence<br/>
        /// will be reported.<br/>
        /// <para></para>
        /// This extrinsic must be called unsigned and it is expected that only<br/>
        /// block authors will call it (validated in `ValidateUnsigned`), as such<br/>
        /// if the block author is defined it will be defined as the equivocation<br/>
        /// reporter.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> ReportEquivocationUnsigned(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof equivocationProof, FinalBiome.Sdk.SpCore.Void keyOwnerProof, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof, FinalBiome.Sdk.SpCore.Void> data = new BaseTuple<FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof, FinalBiome.Sdk.SpCore.Void>();
            data.Create(equivocationProof, keyOwnerProof);
            byte[] parameters = data.Encode();
            Method method = new Method(4, 1, parameters);
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
