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
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 120
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Transfer some liquid free balance to another account.
    /// 
    /// `transfer` will set the `FreeBalance` of the sender and receiver.
    /// If the sender's account is below the existential deposit as a result
    /// of the transfer, the account will be reaped.
    /// 
    /// The dispatch origin for this call must be `Signed` by the transactor.
    /// 
    /// # <weight>
    /// - Dependent on arguments but not critical, given proper implementations for input config
    ///   types. See related functions below.
    /// - It contains a limited number of reads and writes internally and no complex
    ///   computation.
    /// 
    /// Related functions:
    /// 
    ///   - `ensure_can_withdraw` is always called internally but has a bounded complexity.
    ///   - Transferring balances to accounts that did not exist before will cause
    ///     `T::OnNewAccount::on_new_account` to be called.
    ///   - Removing enough funds from an account will trigger `T::DustRemoval::on_unbalanced`.
    ///   - `transfer_keep_alive` works the same way as `transfer`, but has an additional check
    ///     that the transfer will not kill the origin account.
    /// ---------------------------------
    /// - Origin account is already in memory, so no DB operations for them.
    /// # </weight>
    /// </summary>
        transfer,
    /// <summary>
    /// Set the balances of a given account.
    /// 
    /// This will alter `FreeBalance` and `ReservedBalance` in storage. it will
    /// also alter the total issuance of the system (`TotalIssuance`) appropriately.
    /// If the new free or reserved balance is below the existential deposit,
    /// it will reset the account nonce (`frame_system::AccountNonce`).
    /// 
    /// The dispatch origin for this call is `root`.
    /// </summary>
        set_balance,
    /// <summary>
    /// Exactly as `transfer`, except the origin must be root and the source account may be
    /// specified.
    /// # <weight>
    /// - Same as transfer, but additional read and write because the source account is not
    ///   assumed to be in the overlay.
    /// # </weight>
    /// </summary>
        force_transfer,
    /// <summary>
    /// Same as the [`transfer`] call, but with a check that the transfer will not kill the
    /// origin account.
    /// 
    /// 99% of the time you want [`transfer`] instead.
    /// 
    /// [`transfer`]: struct.Pallet.html#method.transfer
    /// </summary>
        transfer_keep_alive,
    /// <summary>
    /// Transfer the entire transferable balance from the caller account.
    /// 
    /// NOTE: This function only attempts to transfer _transferable_ balances. This means that
    /// any locked, reserved, or existential deposits (when `keep_alive` is `true`), will not be
    /// transferred by this function. To ensure that this function results in a killed account,
    /// you might need to prepare the account by removing any reference counters, storage
    /// deposits, etc...
    /// 
    /// The dispatch origin of this call must be Signed.
    /// 
    /// - `dest`: The recipient of the transfer.
    /// - `keep_alive`: A boolean to determine if the `transfer_all` operation should send all
    ///   of the funds the account has, causing the sender account to be killed (false), or
    ///   transfer everything except at least the existential deposit, which will guarantee to
    ///   keep the sender account alive (true). # <weight>
    /// - O(1). Just like transfer, but reading the user's transferable balance first.
    ///   #</weight>
    /// </summary>
        transfer_all,
    /// <summary>
    /// Unreserve some balance from a user by force.
    /// 
    /// Can only be called by ROOT.
    /// </summary>
        force_unreserve,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 120
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128, FinalBiome.Sdk.CompactU128>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.CompactU128>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, Ajuna.NetApi.Model.Types.Primitive.Bool>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, Ajuna.NetApi.Model.Types.Primitive.U128>>
    {
        public override string TypeName() => "Call";
    }
}
