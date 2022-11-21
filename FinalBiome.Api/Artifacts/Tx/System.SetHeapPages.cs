///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class System
    {
        /// <summary>
        /// Set the number of pages in the WebAssembly environment's heap.<br/>
        /// </summary>
        public StaticTxPayload SetHeapPages(FinalBiome.Api.Types.Primitive.U64 pages)
        {
            byte palletIsx = 0;
            byte callIsx = 2;

            List<byte> callData = new List<byte>();
            pages.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
