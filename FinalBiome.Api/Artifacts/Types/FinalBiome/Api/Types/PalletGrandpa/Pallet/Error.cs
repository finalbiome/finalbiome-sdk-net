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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 118
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// Attempt to signal GRANDPA pause when the authority set isn't live<br/>
    /// (either paused or already pending pause).<br/>
    /// </summary>
        PauseFailed = 0,
    /// <summary>
    /// Attempt to signal GRANDPA resume when the authority set isn't paused<br/>
    /// (either live or already pending resume).<br/>
    /// </summary>
        ResumeFailed = 1,
    /// <summary>
    /// Attempt to signal GRANDPA change with one already pending.<br/>
    /// </summary>
        ChangePending = 2,
    /// <summary>
    /// Cannot signal forced change so soon after last.<br/>
    /// </summary>
        TooSoon = 3,
    /// <summary>
    /// A key ownership proof provided as part of an equivocation report is invalid.<br/>
    /// </summary>
        InvalidKeyOwnershipProof = 4,
    /// <summary>
    /// An equivocation proof provided as part of an equivocation report is invalid.<br/>
    /// </summary>
        InvalidEquivocationProof = 5,
    /// <summary>
    /// A given equivocation report is valid but already previously reported.<br/>
    /// </summary>
        DuplicateOffenceReport = 6,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 118
    /// </summary>
    public class Error : Enum<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
