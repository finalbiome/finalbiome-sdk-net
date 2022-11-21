///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class NonFungibleAssets
    {
        /// <summary>
        /// Issue a new non fungible class.<br/>
        /// <para></para>
        /// This new class has owner as orgaization.<br/>
        /// <para></para>
        /// The origin must be Signed.<br/>
        /// <para></para>
        /// Parameters:<br/>
        /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
        /// <para></para>
        /// Emits `Created` event when successful.<br/>
        /// </summary>
        public StaticTxPayload Create(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Api.Types.VecU8 name)
        {
            byte palletIsx = 11;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            name.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
