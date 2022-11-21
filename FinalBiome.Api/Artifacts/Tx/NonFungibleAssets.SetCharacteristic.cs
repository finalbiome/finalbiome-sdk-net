///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class NonFungibleAssets
    {
        public StaticTxPayload SetCharacteristic(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId classId, FinalBiome.Api.Types.PalletSupport.Characteristics.Characteristic characteristic)
        {
            byte palletIsx = 11;
            byte callIsx = 4;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            classId.EncodeTo(ref callData);
            characteristic.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
