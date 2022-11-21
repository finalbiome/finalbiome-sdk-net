///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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
            byte palletIsx = 9;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            who.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
