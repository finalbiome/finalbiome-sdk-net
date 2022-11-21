///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
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
        ///   keep the sender account alive (true). # &lt;weight&gt;<br/>
        /// - O(1). Just like transfer, but reading the user's transferable balance first.<br/>
        ///   #&lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload TransferAll(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress dest, FinalBiome.Api.Types.Primitive.Bool keepAlive)
        {
            byte palletIsx = 5;
            byte callIsx = 4;

            List<byte> callData = new List<byte>();
            dest.EncodeTo(ref callData);
            keepAlive.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
