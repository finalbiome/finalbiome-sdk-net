///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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
