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
        /// Add member to an organization.<br/>
        /// <para></para>
        /// # Events<br/>
        /// * `MemberAdded`<br/>
        /// # Errors<br/>
        /// * `NotOrganization` if origin not an organization<br/>
        /// * `MembershipLimitReached` if members limit exceeded<br/>
        /// * `InvalidMember` if member is organization<br/>
        /// * `AlreadyMember` if member already added<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> AddMember(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpCore.Crypto.AccountId32 who, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32> data = new BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32>();
            data.Create(who);
            byte[] parameters = data.Encode();
            Method method = new Method(9, 1, parameters);
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
