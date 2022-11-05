///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class OrganizationIdentity
    {
        /// <summary>
        /// Create an organization.<br/>
        /// Will return an OrganizationExists error if the organization has already<br/>
        /// been created. Will emit a CreatedOrganization event on success.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be Signed.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> CreateOrganization(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.VecU8 name, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.VecU8> data = new BaseTuple<FinalBiome.Sdk.VecU8>();
            data.Create(name);
            byte[] parameters = data.Encode();
            Method method = new Method(9, 0, parameters);
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
