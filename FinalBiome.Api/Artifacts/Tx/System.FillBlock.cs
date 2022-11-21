///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class System
    {
        /// <summary>
        /// A dispatch that will fill the block weight up to the given ratio.<br/>
        /// </summary>
        public StaticTxPayload FillBlock(FinalBiome.Api.Types.SpArithmetic.PerThings.Perbill ratio)
        {
            byte palletIsx = 0;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            ratio.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
