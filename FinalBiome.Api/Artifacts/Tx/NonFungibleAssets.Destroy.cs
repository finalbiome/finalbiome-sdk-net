///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class NonFungibleAssets
    {
        /// <summary>
        /// Destroy a non fungible asset class.<br/>
        /// <para></para>
        /// The origin must be Signed and must be a member of the organization<br/>
        /// </summary>
        public StaticTxPayload Destroy(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId classId)
        {
            byte palletIsx = 11;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            classId.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
