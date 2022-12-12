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
    public partial class Balances
    {
        /// <summary>
        /// Same as the [`transfer`] call, but with a check that the transfer will not kill the<br/>
        /// origin account.<br/>
        /// <para></para>
        /// 99% of the time you want [`transfer`] instead.<br/>
        /// <para></para>
        /// [`transfer`]: struct.Pallet.html#method.transfer<br/>
        /// </summary>
        public StaticTxPayload TransferKeepAlive(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress dest, FinalBiome.Api.Types.CompactU128 _value)
        {
            byte palletIsx = 5;
            byte callIsx = 3;

            List<byte> callData = new List<byte>();
            dest.EncodeTo(ref callData);
            _value.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
