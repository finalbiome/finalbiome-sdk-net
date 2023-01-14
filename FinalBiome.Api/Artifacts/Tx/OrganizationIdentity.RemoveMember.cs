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
            byte palletIsx = 10;
            byte callIsx = 2;

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
