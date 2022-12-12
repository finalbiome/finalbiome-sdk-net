///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
namespace FinalBiome.Api.Tx
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
        public StaticTxPayload SetBalance(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress who, FinalBiome.Api.Types.CompactU128 newFree, FinalBiome.Api.Types.CompactU128 newReserved)
        {
            byte palletIsx = 5;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            who.EncodeTo(ref callData);
            newFree.EncodeTo(ref callData);
            newReserved.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
