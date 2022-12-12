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
        /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
        /// This function does not check the weight of the call, and instead allows the<br/>
        /// Sudo user to specify the weight of the call.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be _Signed_.<br/>
        /// <para></para>
        /// # &lt;weight&gt;<br/>
        /// - O(1).<br/>
        /// - The weight of this call is defined by the caller.<br/>
        /// # &lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload SudoUncheckedWeight(FinalBiome.Api.Types.FinalbiomeNodeRuntime.Call call, FinalBiome.Api.Types.Primitive.U64 weight)
        {
            byte palletIsx = 7;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            call.EncodeTo(ref callData);
            weight.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
