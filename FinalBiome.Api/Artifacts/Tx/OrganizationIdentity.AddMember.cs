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
        /// Add member to an organization.<br/>
        /// <para></para>
        /// # Events<br/>
        /// * `MemberAdded`<br/>
        /// # Errors<br/>
        /// * `NotOrganization` if origin not an organization<br/>
        /// * `MembershipLimitReached` if members limit exceeded<br/>
        /// * `InvalidMember` if member is organization<br/>
        /// * `AlreadyMember` if member already added<br/>
        /// </summary>
        public StaticTxPayload AddMember(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 who)
        {
            byte palletIsx = 10;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            who.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
