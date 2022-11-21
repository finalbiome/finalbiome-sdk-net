///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class System
    {
        /// <summary>
        /// Make some on-chain remark and emit event.<br/>
        /// </summary>
        public StaticTxPayload RemarkWithEvent(FinalBiome.Api.Types.VecU8 remark)
        {
            byte palletIsx = 0;
            byte callIsx = 8;

            List<byte> callData = new List<byte>();
            remark.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
