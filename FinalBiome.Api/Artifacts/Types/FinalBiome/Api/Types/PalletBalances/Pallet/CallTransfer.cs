///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletBalances.Pallet
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
    /// # &lt;weight&gt;<br/>
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
    /// # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 128, Variant Id 0
    /// </summary>
    public class CallTransfer : Codec
    {
        public override string TypeName() => "CallTransfer";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress Dest { get; private set; }
        public FinalBiome.Api.Types.CompactU128 Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Dest = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            Dest.Decode(byteArray, ref p);

            Value = new FinalBiome.Api.Types.CompactU128();
            Value.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
