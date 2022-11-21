///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class Mechanics
    {
        /// <summary>
        /// Execute mechanic `Bet`<br/>
        /// </summary>
        public StaticTxPayload ExecBet(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId classId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId assetId)
        {
            byte palletIsx = 12;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            classId.EncodeTo(ref callData);
            assetId.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
