
namespace FinalBiome.Sdk;

using ResultRaw = Api.Types.PalletMechanics.Types.EventMechanicResultData;
using Reason = Api.Types.PalletMechanics.Types.EventMechanicStopReason;
using AccountId = Api.Types.SpCore.Crypto.AccountId32;
using FinalBiome.Api.Types.PalletMechanics.Types;
using NfaInstanceId = UInt32;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId;

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
    ResultRaw? _resultRaw;
    public ResultRaw ResultRaw { 
        get
        {
            if (_resultRaw is null) throw new Exception($"Result does not exist for status {Status}");
            return _resultRaw;
        } 
        internal set
        {
            _resultRaw = value;
        }
    }
    public Reason? Reason { get; internal set; }
}

public record struct MxId
{
    public readonly AccountId accountId;
    public readonly ulong nonce;

    public MxId(AccountId accountId, ulong nonce)
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

public class MxResultBuyNfa : MxResult
{
    ResultBuyNfa? _result;
    public ResultBuyNfa Result {
        get
        {
            if (_result is null)
            {
                if (ResultRaw.Value != InnerEventMechanicResultData.BuyNfa) throw new Exception($"Wrong type. Received {ResultRaw.Value}, but Expected InnerEventMechanicResultData.BuyNfa");
                NfaInstanceId instanceId = (NonFungibleAssetId)ResultRaw.Value2;
                _result = new ResultBuyNfa() {
                    InstanceId = instanceId
                };
            }
            return _result;
        }
    }
}

public class MxResultBet : MxResult
{
    ResultBet? _result;
    public ResultBet Result {
        get
        {
            if (_result is null)
            {
                if (ResultRaw.Value != InnerEventMechanicResultData.Bet) throw new Exception($"Wrong type. Received {ResultRaw.Value}, but Expected InnerEventMechanicResultData.BuyNfa");
                EventMechanicResultDataBet data = (EventMechanicResultDataBet)ResultRaw.Value2;
                _result = new ResultBet() {
                    BetResult = (BetResult)(byte)data.Result.Value,
                    Outcomes = data.Outcomes.Value.Select(v => (uint)v).ToList(),
                };
            }
            return _result;
        }
    }
}

public class ResultBuyNfa
{
    /// <summary>
    /// Instance Id of the purchased Nfa.
    /// </summary>
    /// <value></value>
    public NfaInstanceId InstanceId { get; internal set; }
}

public class ResultBet
{
    public List<uint> Outcomes { get; internal set; }
    public BetResult BetResult { get; internal set; }
}

public enum BetResult : byte {
    Won = 0,
    Lost = 1,
    Draw = 2,
}
