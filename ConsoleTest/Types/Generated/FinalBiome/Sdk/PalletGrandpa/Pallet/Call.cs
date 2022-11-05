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
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 98
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Report voter equivocation/misbehavior. This method will verify the<br/>
    /// equivocation proof and validate the given key ownership proof<br/>
    /// against the extracted offender. If both are valid, the offence<br/>
    /// will be reported.<br/>
    /// </summary>
        report_equivocation,
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
        report_equivocation_unsigned,
    /// <summary>
    /// Note that the current authority set of the GRANDPA finality gadget has stalled.<br/>
    /// <para></para>
    /// This will trigger a forced authority set change at the beginning of the next session, to<br/>
    /// be enacted `delay` blocks after that. The `delay` should be high enough to safely assume<br/>
    /// that the block signalling the forced change will not be re-orged e.g. 1000 blocks.<br/>
    /// The block production rate (which may be slowed down because of finality lagging) should<br/>
    /// be taken into account when choosing the `delay`. The GRANDPA voters based on the new<br/>
    /// authority will start voting on top of `best_finalized_block_number` for new finalized<br/>
    /// blocks. `best_finalized_block_number` should be the highest of the latest finalized<br/>
    /// block of all validators of the new authority set.<br/>
    /// <para></para>
    /// Only callable by root.<br/>
    /// </summary>
        note_stalled,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 98
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, BaseTuple<FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof, FinalBiome.Sdk.SpCore.Void>, BaseTuple<FinalBiome.Sdk.SpFinalityGrandpa.EquivocationProof, FinalBiome.Sdk.SpCore.Void>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, Ajuna.NetApi.Model.Types.Primitive.U32>>
    {
        public override string TypeName() => "Call";
    }
}
