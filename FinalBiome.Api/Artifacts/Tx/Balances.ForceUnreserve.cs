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
        /// Unreserve some balance from a user by force.<br/>
        /// <para></para>
        /// Can only be called by ROOT.<br/>
        /// </summary>
        public StaticTxPayload ForceUnreserve(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress who, FinalBiome.Api.Types.Primitive.U128 amount)
        {
            byte palletIsx = 5;
            byte callIsx = 5;

            List<byte> callData = new List<byte>();
            who.EncodeTo(ref callData);
            amount.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
