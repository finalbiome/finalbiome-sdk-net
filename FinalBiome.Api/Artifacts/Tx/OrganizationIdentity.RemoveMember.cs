///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class OrganizationIdentity
    {
        /// <summary>
        /// Removes a member from organization.<br/>
        /// <para></para>
        /// # Events<br/>
        /// * `MemberRemoved`<br/>
        /// <para></para>
        /// # Errors<br/>
        /// * `NotOrganization` if origin not an organization<br/>
        /// * `NotMember` if a member doesn't exist<br/>
        /// * ``<br/>
        /// </summary>
        public StaticTxPayload RemoveMember(FinalBiome.Api.Types.SpCore.Crypto.AccountId32 who)
        {
            byte palletIsx = 9;
            byte callIsx = 2;

            List<byte> callData = new List<byte>();
            who.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
