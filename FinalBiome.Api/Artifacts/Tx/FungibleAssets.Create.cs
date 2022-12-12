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
    public partial class FungibleAssets
    {
        /// <summary>
        /// Issue a new fungible asset from.<br/>
        /// <para></para>
        /// This new asset has owner as orgaization.<br/>
        /// <para></para>
        /// The origin must be Signed.<br/>
        /// <para></para>
        /// <para></para>
        /// Parameters:<br/>
        /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
        /// <para></para>
        /// Emits `Created` event when successful.<br/>
        /// </summary>
        public StaticTxPayload Create(FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress organizationId, FinalBiome.Api.Types.VecU8 name, FinalBiome.Api.Types.OptionTopUppedFA topUpped, FinalBiome.Api.Types.OptionCupFA cupGlobal, FinalBiome.Api.Types.OptionCupFA cupLocal)
        {
            byte palletIsx = 10;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            organizationId.EncodeTo(ref callData);
            name.EncodeTo(ref callData);
            topUpped.EncodeTo(ref callData);
            cupGlobal.EncodeTo(ref callData);
            cupLocal.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
