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
        /// Transfer some liquid free balance to another account.<br/>
        /// <para></para>
        /// `transfer` will set the `FreeBalance` of the sender and receiver.<br/>
        /// If the sender's account is below the existential deposit as a result<br/>
        /// of the transfer, the account will be reaped.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be `Signed` by the transactor.<br/>
        /// <para></para>
        /// # <weight><br/>
        /// - Dependent on arguments but not critical, given proper implementations for input config<br/>
        ///   types. See related functions below.<br/>
        /// - It contains a limited number of reads and writes internally and no complex<br/>
        ///   computation.<br/>
        /// <para></para>
        /// Related functions:<br/>
        /// <para></para>
        ///   - `ensure_can_withdraw` is always called internally but has a bounded complexity.<br/>
        ///   - Transferring balances to accounts that did not exist before will cause<br/>
        ///     `T::OnNewAccount::on_new_account` to be called.<br/>
        ///   - Removing enough funds from an account will trigger `T::DustRemoval::on_unbalanced`.<br/>
        ///   - `transfer_keep_alive` works the same way as `transfer`, but has an additional check<br/>
        ///     that the transfer will not kill the origin account.<br/>
        /// ---------------------------------<br/>
        /// - Origin account is already in memory, so no DB operations for them.<br/>
        /// # </weight><br/>
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<string?> Transfer(Ajuna.NetApi.Model.Types.Account account, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress dest, FinalBiome.Sdk.CompactU128 _value, Func<string, ExtrinsicStatus, Task>? subscription = null, CancellationToken? token = null)
        {
            BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128> data = new BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128>();
            data.Create(dest, _value);
            byte[] parameters = data.Encode();
            Method method = new Method(5, 0, parameters);
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
