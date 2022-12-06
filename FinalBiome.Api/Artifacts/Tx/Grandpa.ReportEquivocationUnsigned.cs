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
    public partial class Grandpa
    {
        /// <summary>
        /// Report voter equivocation/misbehavior. This method will verify the<br/>
        /// equivocation proof and validate the given key ownership proof<br/>
        /// against the extracted offender. If both are valid, the offence<br/>
        /// will be reported.<br/>
        /// <para></para>
        /// This extrinsic must be called unsigned and it is expected that only<br/>
        /// block authors will call it (validated in `ValidateUnsigned`), as such<br/>
        /// if the block author is defined it will be defined as the equivocation<br/>
        /// reporter.<br/>
        /// </summary>
        public StaticTxPayload ReportEquivocationUnsigned(FinalBiome.Api.Types.SpFinalityGrandpa.EquivocationProof equivocationProof, FinalBiome.Api.Types.SpCore.Void keyOwnerProof)
        {
            byte palletIsx = 4;
            byte callIsx = 1;

            List<byte> callData = new List<byte>();
            equivocationProof.EncodeTo(ref callData);
            keyOwnerProof.EncodeTo(ref callData);

            return new StaticTxPayload(palletIsx, callIsx, callData);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
