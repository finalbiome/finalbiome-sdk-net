///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class FungibleAssets
    {
        /// <summary>
        /// Issue a new fungible asset from.<br/>
        /// <para></para>
        /// This new asset has owner as orgaization.<br/>
        /// <para></para>
        /// The origin must be Signed.<br/>
        /// <para></para>
        /// <para></para>
        /// Parameters:<br/>
        /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
        /// <para></para>
        /// Emits `Created` event when successful.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> Create(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Sdk.VecU8 name, FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA topUpped, FinalBiome.Sdk.Model.Types.Base.OptionCupFA cupGlobal, FinalBiome.Sdk.Model.Types.Base.OptionCupFA cupLocal, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.VecU8, FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA, FinalBiome.Sdk.Model.Types.Base.OptionCupFA, FinalBiome.Sdk.Model.Types.Base.OptionCupFA> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.VecU8, FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA, FinalBiome.Sdk.Model.Types.Base.OptionCupFA, FinalBiome.Sdk.Model.Types.Base.OptionCupFA>();
            data.Create(organizationId, name, topUpped, cupGlobal, cupLocal);
            byte[] parameters = data.Encode();
            Method method = new Method(10, 0, parameters);
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
