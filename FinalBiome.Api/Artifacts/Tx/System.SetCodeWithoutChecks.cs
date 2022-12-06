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
    public partial class System
    {
        /// <summary>
        /// Set the new runtime code without doing any checks of the given `code`.<br/>
        /// <para></para>
        /// # &lt;weight&gt;<br/>
        /// - `O(C)` where `C` length of `code`<br/>
        /// - 1 storage write (codec `O(C)`).<br/>
        /// - 1 digest item.<br/>
        /// - 1 event.<br/>
        /// The weight of this function is dependent on the runtime. We will treat this as a full<br/>
        /// block. # &lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload SetCodeWithoutChecks(FinalBiome.Api.Types.VecU8 code)
        {
            byte palletIsx = 0;
            byte callIsx = 4;

            List<byte> callData = new List<byte>();
            code.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
