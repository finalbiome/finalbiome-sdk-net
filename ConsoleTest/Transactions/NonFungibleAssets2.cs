using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public class NonFungibleAssets2
    {
        readonly Client _client;

        public NonFungibleAssets2(Client client)
        {
            _client = client;
        }

        /// <summary>
        /// "Issue a new non fungible class.",
        /// "",
        /// "This new class has owner as orgaization.",
        /// "",
        /// "The origin must be Signed.",
        /// "",
        /// "Parameters:",
        /// "- `organization_id`: The identifier of the organization. Origin must be member of it.",
        /// "",
        /// "Emits `Created` event when successful."
        /// </summary>
        /// <param name="account"></param>
        /// <param name="organizationId"></param>
        /// <param name="nfaName"></param>
        /// <param name="subscription"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> Create(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Sdk.VecU8 nfaName, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.VecU8> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, VecU8>();
            data.Create(organizationId, nfaName);
            byte[] parameters = data.Encode();
            Method method = new Method(11 /* module NonFungibleAssets */, 0 /* call create */, parameters);

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

