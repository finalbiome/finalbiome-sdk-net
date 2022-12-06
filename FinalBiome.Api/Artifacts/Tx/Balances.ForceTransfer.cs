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
        /// Exactly as `transfer`, except the origin must be root and the source account may be<br/>
        /// specified.<br/>
        /// # &lt;weight&gt;<br/>
        /// - Same as transfer, but additional read and write because the source account is not<br/>
        ///   assumed to be in the overlay.<br/>
        /// # &lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload ForceTransfer(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress source, FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress dest, FinalBiome.Api.Types.CompactU128 _value)
        {
            byte palletIsx = 5;
            byte callIsx = 2;

            List<byte> callData = new List<byte>();
            source.EncodeTo(ref callData);
            dest.EncodeTo(ref callData);
            _value.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
