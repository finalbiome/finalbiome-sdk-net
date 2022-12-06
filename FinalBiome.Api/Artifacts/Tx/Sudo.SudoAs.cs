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
    public partial class Sudo
    {
        /// <summary>
        /// Authenticates the sudo key and dispatches a function call with `Signed` origin from<br/>
        /// a given account.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be _Signed_.<br/>
        /// <para></para>
        /// # &lt;weight&gt;<br/>
        /// - O(1).<br/>
        /// - Limited storage reads.<br/>
        /// - One DB write (event).<br/>
        /// - Weight of derivative `call` execution + 10,000.<br/>
        /// # &lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload SudoAs(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress who, FinalBiome.Api.Types.FinalbiomeNodeRuntime.Call call)
        {
            byte palletIsx = 7;
            byte callIsx = 3;

            List<byte> callData = new List<byte>();
            who.EncodeTo(ref callData);
            call.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
