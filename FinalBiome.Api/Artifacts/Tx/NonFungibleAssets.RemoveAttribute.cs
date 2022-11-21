///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class NonFungibleAssets
    {
        /// <summary>
        /// Removes an attribute for the non fungible asset class.<br/>
        /// The origin must be Signed, be a member of the organization<br/>
        /// and that organization must be a owner of the asset class.<br/>
        /// </summary>
        public StaticTxPayload RemoveAttribute(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId classId, FinalBiome.Api.Types.BoundedVecU8 attributeName)
        {
            byte palletIsx = 11;
            byte callIsx = 3;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            classId.EncodeTo(ref callData);
            attributeName.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
