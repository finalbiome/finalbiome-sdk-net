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
        /// Execute mechanic `Buy NFA`<br/>
        /// </summary>
        public StaticTxPayload ExecBuyNfa(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 organizationId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId classId, FinalBiome.Api.Types.Primitive.U32 offerId)
        {
            byte palletIsx = 12;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            classId.EncodeTo(ref callData);
            offerId.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
