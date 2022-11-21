///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
namespace FinalBiome.Api.Tx
{
    public partial class Grandpa
    {
        /// <summary>
        /// Report voter equivocation/misbehavior. This method will verify the<br/>
        /// equivocation proof and validate the given key ownership proof<br/>
        /// against the extracted offender. If both are valid, the offence<br/>
        /// will be reported.<br/>
        /// </summary>
        public StaticTxPayload ReportEquivocation(FinalBiome.Api.Types.SpFinalityGrandpa.EquivocationProof equivocationProof, FinalBiome.Api.Types.SpCore.Void keyOwnerProof)
        {
            byte palletIsx = 4;
            byte callIsx = 0;

            List<byte> callData = new List<byte>();
            equivocationProof.EncodeTo(ref callData);
            keyOwnerProof.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}
