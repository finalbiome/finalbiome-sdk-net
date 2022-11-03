///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletGrandpa.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 98
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Report voter equivocation/misbehavior. This method will verify the
    /// equivocation proof and validate the given key ownership proof
    /// against the extracted offender. If both are valid, the offence
    /// will be reported.
    /// </summary>
        report_equivocation,
    /// <summary>
    /// Report voter equivocation/misbehavior. This method will verify the
    /// equivocation proof and validate the given key ownership proof
    /// against the extracted offender. If both are valid, the offence
    /// will be reported.
    /// 
    /// This extrinsic must be called unsigned and it is expected that only
    /// block authors will call it (validated in `ValidateUnsigned`), as such
    /// if the block author is defined it will be defined as the equivocation
    /// reporter.
    /// </summary>
        report_equivocation_unsigned,
    /// <summary>
    /// Note that the current authority set of the GRANDPA finality gadget has stalled.
    /// 
    /// This will trigger a forced authority set change at the beginning of the next session, to
    /// be enacted `delay` blocks after that. The `delay` should be high enough to safely assume
    /// that the block signalling the forced change will not be re-orged e.g. 1000 blocks.
    /// The block production rate (which may be slowed down because of finality lagging) should
    /// be taken into account when choosing the `delay`. The GRANDPA voters based on the new
    /// authority will start voting on top of `best_finalized_block_number` for new finalized
    /// blocks. `best_finalized_block_number` should be the highest of the latest finalized
    /// block of all validators of the new authority set.
    /// 
    /// Only callable by root.
    /// </summary>
        note_stalled,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 98
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, BaseTuple<FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof, FinalBiome.Sdk.SpCore.Void>, BaseTuple<FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof, FinalBiome.Sdk.SpCore.Void>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
        public override string TypeName() => "Call";
    }
}
