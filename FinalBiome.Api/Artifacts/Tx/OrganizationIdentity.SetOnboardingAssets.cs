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

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
