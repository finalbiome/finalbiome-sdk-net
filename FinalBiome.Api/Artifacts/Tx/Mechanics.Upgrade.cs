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
    public partial class Mechanics
    {
        /// <summary>
        /// Upgrade mechanic<br/>
        /// </summary>
        public StaticTxPayload Upgrade(FinalBiome.Api.Types.PalletMechanics.Types.MechanicUpgradeData upgrageData)
        {
            byte palletIsx = 12;
            byte callIsx = 2;

            List<byte> callData = new List<byte>();
            upgrageData.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
