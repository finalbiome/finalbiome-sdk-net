///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class OrganizationIdentity
    {
        /// <summary>
        /// Set assets which will be airdroped at game onboarding<br/>
        /// </summary>
        public StaticTxPayload SetOnboardingAssets(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 organizationId, FinalBiome.Api.Types.OptionBoundedVecAirDropAsset assets)
        {
            byte palletIsx = 9;
            byte callIsx = 3;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            assets.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
