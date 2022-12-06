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
        /// Set some items of storage.<br/>
        /// </summary>
        public StaticTxPayload SetStorage(FinalBiome.Api.Types.VecTuple_VecU8_VecU8 items)
        {
            byte palletIsx = 0;
            byte callIsx = 5;

            List<byte> callData = new List<byte>();
            items.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
