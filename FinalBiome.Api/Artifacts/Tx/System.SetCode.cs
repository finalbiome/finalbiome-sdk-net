///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class System
    {
        /// <summary>
        /// Set the new runtime code.<br/>
        /// <para></para>
        /// # &lt;weight&gt;<br/>
        /// - `O(C + S)` where `C` length of `code` and `S` complexity of `can_set_code`<br/>
        /// - 1 call to `can_set_code`: `O(S)` (calls `sp_io::misc::runtime_version` which is<br/>
        ///   expensive).<br/>
        /// - 1 storage write (codec `O(C)`).<br/>
        /// - 1 digest item.<br/>
        /// - 1 event.<br/>
        /// The weight of this function is dependent on the runtime, but generally this is very<br/>
        /// expensive. We will treat this as a full block.<br/>
        /// # &lt;/weight&gt;<br/>
        /// </summary>
        public StaticTxPayload SetCode(FinalBiome.Api.Types.VecU8 code)
        {
            byte palletIsx = 0;
            byte callIsx = 3;

            List<byte> callData = new List<byte>();
            code.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
