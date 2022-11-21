///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class System
    {
        /// <summary>
        /// Kill all storage items with a key that starts with the given prefix.<br/>
        /// <para></para>
        /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under<br/>
        /// the prefix we are removing to accurately calculate the weight of this function.<br/>
        /// </summary>
        public StaticTxPayload KillPrefix(FinalBiome.Api.Types.VecU8 prefix, FinalBiome.Api.Types.Primitive.U32 subkeys)
        {
            byte palletIsx = 0;
            byte callIsx = 7;

            List<byte> callData = new List<byte>();
            prefix.EncodeTo(ref callData);
            subkeys.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
