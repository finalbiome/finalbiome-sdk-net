using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleAssetId;
using FinalBiome.Api.Types.PalletMechanics.Types;
using FinalBiome.Api.Types.PalletSupport;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Sdk;

using ResultRaw = Api.Types.PalletMechanics.Types.EventMechanicResultData;
using ReasonRaw = Api.Types.PalletMechanics.Types.EventMechanicStopReason;
using AccountId = Api.Types.SpCore.Crypto.AccountId32;
using NfaInstanceId = UInt32;
using GamerAccount = FinalBiome.Api.Types.PalletSupport.GamerAccount;

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
    ReasonRaw? _reasonRaw;

    public ReasonRaw ReasonRaw
    {
        get
        {
            if (_reasonRaw is null) throw new Exception($"Result does not exist for status {Status}");
            return _reasonRaw;
        }
        internal set
        {
            _reasonRaw = value;
        }
    }

    public StopReason StopReason
    {
        get
        {
            return (StopReason)(byte)ReasonRaw.Value;
        }
    }
}

/// <summary>
/// Id of the mechanics.
/// </summary>
public record struct MxId
{
    public readonly GamerAccount gamerAccount;
    public readonly ulong nonce;

    public MxId(GamerAccount gamerAccount, ulong nonce)
    {
        this.gamerAccount = gamerAccount;
        this.nonce = nonce;
    }

    public static implicit operator MechanicId(MxId v)
    {
        MechanicId res = new();
        res.Init(
            v.gamerAccount.Encode()
            .Concat(U32.From((uint)v.nonce).Encode())
            .ToArray()
        );
        return res;
    }
    public static implicit operator MxId(MechanicId v)
    {
        MxId res = new(v.GamerAccount, v.Nonce);
        return res;
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

    MechanicsDetails<MechanicDataBet>? _reason;
    public MechanicsDetails<MechanicDataBet> Reason
    {
        get
        {
            if (_reason is null)
            {
                if (ReasonRaw.Value != InnerEventMechanicStopReason.UpgradeNeeded) throw new Exception($"Wrong type. Received {ReasonRaw.Value}, but Expected InnerEventMechanicStopReason.UpgradeNeeded");
                var data = (FinalBiome.Api.Types.PalletMechanics.Types.MechanicDetails)ReasonRaw.Value2;

                if (data.Data.Value != InnerMechanicData.Bet) throw new Exception($"Wrong type. Received {ReasonRaw.Value}, but Expected InnerMechanicData.Bet");
                var betData = (FinalBiome.Api.Types.PalletMechanics.Types.MechanicDataBet)data.Data.Value2;
                var outcomes = betData.Outcomes.Value.Select(v => (uint)v).ToList();

                _reason = new(
                    data.Owner,
                    data.TimeoutId,
                    data.Locked,
                    new MechanicDataBet(outcomes)
                );
            }
            return _reason;
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

/// <summary>
/// Result of the Bet mechanics.
/// There are Outcomes, as a list of results of finished rounds (in ids defined in Nfa Bettor characteristic)
/// and 
/// </summary>
public class ResultBet
{
#pragma warning disable CS8618
    public List<uint> Outcomes { get; internal set; }
#pragma warning restore CS8618
    public BetResult BetResult { get; internal set; }
}

/// <summary>
/// Final result of the Bet mechanics.
/// </summary>
public enum BetResult : byte {
    Won = 0,
    Lost = 1,
    Draw = 2,
}

public enum StopReason : byte
{
    UpgradeNeeded = 0,
}

/// <summary>
/// Represents the information about the mechanics.
/// </summary>
/// <typeparam name="TData">Type of the data of hte specific mechanics</typeparam>
public class MechanicsDetails<TData>
{
    /// <summary>
    /// Initiator of the mechanics
    /// </summary>
    public GamerAccount Owner { get; internal set; }
    /// <summary>
    /// Block number, when the mechanic will be dropped
    /// </summary>
    public uint Timeout { get; internal set; }
    /// <summary>
    /// List of assets which locked by thos mechanic
    /// </summary>
    public List<LockedAccet> LockedAccet { get; internal set; }
    /// <summary>
    /// The data of this mechanics.
    /// </summary>
    public TData Data { get; internal set; }

    public MechanicsDetails(GamerAccount owner, uint timeout, List<LockedAccet> lockedAccet, TData data)
    {
        Owner = owner;
        Timeout = timeout;
        LockedAccet = lockedAccet;
        Data = data;
    }
}

/// <summary>
/// Intermediate data of the Bet mechanics.
/// </summary>
public class MechanicDataBet
{
    /// <summary>
    /// Current state of the bettor asset with rounds played.
    /// </summary>
    /// <value></value>
    public List<uint> Outcomes { get; internal set; }

    public MechanicDataBet(List<uint> outcomes)
    {
        Outcomes = outcomes;
    }
}
