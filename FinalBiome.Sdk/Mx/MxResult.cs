
namespace FinalBiome.Sdk;

using Result = Api.Types.PalletMechanics.Types.EventMechanicResultData;
using Reason = Api.Types.PalletMechanics.Types.EventMechanicStopReason;
using AccountId = Api.Types.SpCore.Crypto.AccountId32;
using Index = Api.Types.Primitive.U32;

/// <summary>
/// The result of the mechanics execution.
/// There are two results can be:
/// - Finished
/// - Stopped
/// </summary>
public class MxResult
{
    public MxId Id { get; internal set; }
    public ResultStatus Status { get; internal set; }
    public Result? Result { get; internal set; }
    public Reason? Reason { get; internal set; }
}

public record struct MxId
{
    public readonly AccountId accountId;
    public readonly Index nonce;

    public MxId(AccountId accountId, Index nonce)
    {
        this.accountId = accountId;
        this.nonce = nonce;
    }
}

public enum ResultStatus
{
    /// Mechanics done.
    Finished,
    /// Mechanics was stopped.
    Stopped,
}
