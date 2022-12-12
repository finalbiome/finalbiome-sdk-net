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

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
