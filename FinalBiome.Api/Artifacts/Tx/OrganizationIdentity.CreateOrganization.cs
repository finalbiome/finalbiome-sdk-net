///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class OrganizationIdentity
    {
        /// <summary>
        /// Create an organization.<br/>
        /// Will return an OrganizationExists error if the organization has already<br/>
        /// been created. Will emit a CreatedOrganization event on success.<br/>
        /// <para></para>
        /// The dispatch origin for this call must be Signed.<br/>
        /// </summary>
        public StaticTxPayload CreateOrganization(FinalBiome.Api.Types.VecU8 name)
        {
            byte palletIsx = 9;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            name.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
