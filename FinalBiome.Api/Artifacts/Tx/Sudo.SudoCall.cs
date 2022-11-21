///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class Sudo
    {
        /// <summary>
        /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
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
        public StaticTxPayload SudoCall(FinalBiome.Api.Types.FinalbiomeNodeRuntime.Call call)
        {
            byte palletIsx = 7;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            call.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
