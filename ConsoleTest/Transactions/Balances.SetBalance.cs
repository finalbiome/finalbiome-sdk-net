///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Transactions
{
    public partial class Balances
    {
        /// <summary>
        /// Set the balances of a given account.<br/>
        /// <para></para>
        /// This will alter `FreeBalance` and `ReservedBalance` in storage. it will<br/>
        /// also alter the total issuance of the system (`TotalIssuance`) appropriately.<br/>
        /// If the new free or reserved balance is below the existential deposit,<br/>
        /// it will reset the account nonce (`frame_system::AccountNonce`).<br/>
        /// <para></para>
        /// The dispatch origin for this call is `root`.<br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> SetBalance(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress who, FinalBiome.Sdk.CompactU128 newFree, FinalBiome.Sdk.CompactU128 newReserved, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128, FinalBiome.Sdk.CompactU128> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128, FinalBiome.Sdk.CompactU128>();
            data.Create(who, newFree, newReserved);
            byte[] parameters = data.Encode();
            Method method = new Method(5, 1, parameters);
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
