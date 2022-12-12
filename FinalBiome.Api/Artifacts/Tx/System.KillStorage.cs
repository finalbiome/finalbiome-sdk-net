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

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
