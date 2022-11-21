///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class Mechanics
    {
        /// <summary>
        /// Execute mechanic `Buy NFA`<br/>
        /// </summary>
        public StaticTxPayload ExecBuyNfa(FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId classId, FinalBiome.Api.Types.Primitive.U32 offerId)
        {
            byte palletIsx = 12;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            classId.EncodeTo(ref callData);
            offerId.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
