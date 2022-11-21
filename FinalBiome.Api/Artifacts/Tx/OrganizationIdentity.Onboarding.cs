///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class OrganizationIdentity
    {
        /// <summary>
        /// Onboirding to game<br/>
        /// </summary>
        public StaticTxPayload Onboarding(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 organizationId)
        {
            byte palletIsx = 9;
            byte callIsx = 4;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
