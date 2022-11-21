///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class System
    {
        /// <summary>
        /// Kill some items from storage.<br/>
        /// </summary>
        public StaticTxPayload KillStorage(FinalBiome.Api.Types.VecVecU8 keys)
        {
            byte palletIsx = 0;
            byte callIsx = 6;

            List<byte> callData = new List<byte>();
            keys.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
