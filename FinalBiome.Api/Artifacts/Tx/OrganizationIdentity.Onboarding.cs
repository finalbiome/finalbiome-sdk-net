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
        /// Onboirding to game<br/>
        /// </summary>
        public StaticTxPayload Onboarding(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 organizationId)
        {
            byte palletIsx = 10;
            byte callIsx = 4;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
