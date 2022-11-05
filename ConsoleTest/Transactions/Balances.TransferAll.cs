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
        /// Transfer the entire transferable balance from the caller account.<br/>
        /// <para></para>
        /// NOTE: This function only attempts to transfer _transferable_ balances. This means that<br/>
        /// any locked, reserved, or existential deposits (when `keep_alive` is `true`), will not be<br/>
        /// transferred by this function. To ensure that this function results in a killed account,<br/>
        /// you might need to prepare the account by removing any reference counters, storage<br/>
        /// deposits, etc...<br/>
        /// <para></para>
        /// The dispatch origin of this call must be Signed.<br/>
        /// <para></para>
        /// - `dest`: The recipient of the transfer.<br/>
        /// - `keep_alive`: A boolean to determine if the `transfer_all` operation should send all<br/>
        ///   of the funds the account has, causing the sender account to be killed (false), or<br/>
        ///   transfer everything except at least the existential deposit, which will guarantee to<br/>
        ///   keep the sender account alive (true). # <weight><br/>
        /// - O(1). Just like transfer, but reading the user's transferable balance first.<br/>
        ///   #</weight><br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> TransferAll(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress dest, Ajuna.NetApi.Model.Types.Primitive.Bool keepAlive, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, Ajuna.NetApi.Model.Types.Primitive.Bool> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, Ajuna.NetApi.Model.Types.Primitive.Bool>();
            data.Create(dest, keepAlive);
            byte[] parameters = data.Encode();
            Method method = new Method(5, 4, parameters);
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
