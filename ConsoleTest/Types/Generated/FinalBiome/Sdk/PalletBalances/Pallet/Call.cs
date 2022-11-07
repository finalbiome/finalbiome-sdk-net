///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 120
    /// </summary>
    public enum InnerCall
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
        transfer,
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
        set_balance,
    /// <summary>
    /// Exactly as `transfer`, except the origin must be root and the source account may be<br/>
    /// specified.<br/>
    /// # <weight><br/>
    /// - Same as transfer, but additional read and write because the source account is not<br/>
    ///   assumed to be in the overlay.<br/>
    /// # </weight><br/>
    /// </summary>
        force_transfer,
    /// <summary>
    /// Same as the [`transfer`] call, but with a check that the transfer will not kill the<br/>
    /// origin account.<br/>
    /// <para></para>
    /// 99% of the time you want [`transfer`] instead.<br/>
    /// <para></para>
    /// [`transfer`]: struct.Pallet.html#method.transfer<br/>
    /// </summary>
        transfer_keep_alive,
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
        transfer_all,
    /// <summary>
    /// Unreserve some balance from a user by force.<br/>
    /// <para></para>
    /// Can only be called by ROOT.<br/>
    /// </summary>
        force_unreserve,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 120
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.PalletBalances.Pallet.CallTransfer, FinalBiome.Sdk.PalletBalances.Pallet.CallSetBalance, FinalBiome.Sdk.PalletBalances.Pallet.CallForceTransfer, FinalBiome.Sdk.PalletBalances.Pallet.CallTransferKeepAlive, FinalBiome.Sdk.PalletBalances.Pallet.CallTransferAll, FinalBiome.Sdk.PalletBalances.Pallet.CallForceUnreserve>
    {
        public override string TypeName() => "Call";
    }
}
