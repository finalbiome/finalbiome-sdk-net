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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 111
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Attempt to signal GRANDPA pause when the authority set isn't live<br/>
    /// (either paused or already pending pause).<br/>
    /// </summary>
        PauseFailed,
    /// <summary>
    /// Attempt to signal GRANDPA resume when the authority set isn't paused<br/>
    /// (either live or already pending resume).<br/>
    /// </summary>
        ResumeFailed,
    /// <summary>
    /// Attempt to signal GRANDPA change with one already pending.<br/>
    /// </summary>
        ChangePending,
    /// <summary>
    /// Cannot signal forced change so soon after last.<br/>
    /// </summary>
        TooSoon,
    /// <summary>
    /// A key ownership proof provided as part of an equivocation report is invalid.<br/>
    /// </summary>
        InvalidKeyOwnershipProof,
    /// <summary>
    /// An equivocation proof provided as part of an equivocation report is invalid.<br/>
    /// </summary>
        InvalidEquivocationProof,
    /// <summary>
    /// A given equivocation report is valid but already previously reported.<br/>
    /// </summary>
        DuplicateOffenceReport,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 111
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
