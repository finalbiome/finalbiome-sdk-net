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
    public partial class NonFungibleAssets
    {
        /// <summary>
        /// Creates an attribute for the non fungible asset class.<br/>
        /// The origin must be Signed, be a member of the organization<br/>
        /// and that organization must be a owner of the asset class.<br/>
        /// </summary>
        public StaticTxPayload CreateAttribute(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId classId, FinalBiome.Api.Types.PalletSupport.Attribute attribute)
        {
            byte palletIsx = 12;
            byte callIsx = 2;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            classId.EncodeTo(ref callData);
            attribute.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
