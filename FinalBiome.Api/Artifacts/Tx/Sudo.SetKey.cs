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
        /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo<br/>
        /// key.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be _Signed_.<br/>
        /// <para></para>
        /// # &lt;weight&gt;<br/>
        /// - O(1).<br/>
        /// - Limited storage reads.<br/>
        /// - One DB change.<br/>
        /// # &lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload SetKey(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress _new)
        {
            byte palletIsx = 7;
            byte callIsx = 2;

            List<byte> callData = new List<byte>();
            _new.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
