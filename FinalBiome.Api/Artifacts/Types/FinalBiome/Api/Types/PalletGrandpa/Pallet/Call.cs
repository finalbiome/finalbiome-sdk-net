///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletGrandpa.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 106
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// Report voter equivocation/misbehavior. This method will verify the<br/>
    /// equivocation proof and validate the given key ownership proof<br/>
    /// against the extracted offender. If both are valid, the offence<br/>
    /// will be reported.<br/>
    /// </summary>
        report_equivocation = 0,
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
        report_equivocation_unsigned = 1,
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
        note_stalled = 2,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 106
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletGrandpa.Pallet.CallReportEquivocation, FinalBiome.Api.Types.PalletGrandpa.Pallet.CallReportEquivocationUnsigned, FinalBiome.Api.Types.PalletGrandpa.Pallet.CallNoteStalled>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
