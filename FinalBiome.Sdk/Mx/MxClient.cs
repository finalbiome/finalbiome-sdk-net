using System.Collections.Concurrent;

namespace FinalBiome.Sdk;

using FinalBiome.Api.Blocks;
using FinalBiome.Api.Tx;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using OfferId = UInt32;
using MechanicsData = FinalBiome.Api.Types.PalletMechanics.Types.MechanicData;
using GamerAccount = FinalBiome.Api.Types.PalletSupport.GamerAccount;

/// <summary>
/// Client for access mechanics execution and mechanics traction.
/// </summary>
/// When the client is initialized, all current (not completed) mechanics are obtained 
/// and a subscription is made to track their status.
/// 
/// The result of the execution of the mechanics, if applicable, is returned in a network event.
/// There are two types of events
/// 1. Finished - indicates that the execution of the mechanics has completed.
/// 2. Stopped - indicates that the execution of the mechanic is suspended and will continue after it is upgraded.
/// Events contain information about the result of the execution of the mechanics, if applicable.
/// 
/// It is also possible for a number of errors to occur when trying to execute the mechanics.
/// The MxClient returns an error result when trying to start the mechanic.
/// 
/// methods prefixed with exec refer to starting different types of mechanics.
/// The result of calling such a method is the id of the mechanic, 
/// required to get the current status of the mechanic and so on.
public class MxClient : IDisposable
{
    readonly Client client;

    /// <summary>
    /// Current nonce that can used for submitting Tx
    /// </summary>
    internal ulong accountNonce;
    readonly PairSigner signer;

    /// <summary>
    /// All current active mechanics.
    /// If mechanics is not finished, it is here.
    /// </summary>
    readonly ConcurrentDictionary<MxId, MechanicsData> activeMechanics;

    private MxClient(Client client, PairSigner signer, ulong accountNonce)
    {
        this.client = client;
        this.signer = signer;
        this.accountNonce = accountNonce;
    }

    internal static async Task<MxClient> Create(Client client, PairSigner signer)
    {
        var accountNonce = await FetchNonce(client);
        MxClient mxClient = new(client, signer, accountNonce);

        return mxClient;
    }

    /// <summary>
    /// Execute mechanics `Buy NFA`.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="offerId"></param>
    /// <returns></returns>
    public async Task<MxResultBuyNfa> ExecBuyNfa(NfaClassId classId, OfferId offerId)
    {
        // Construct call payload
        var organizationId = client.Game.Address;
        var callTx = client.api.Tx.Mechanics.ExecBuyNfa(organizationId, classId, offerId);

        return await SubmitMx<MxResultBuyNfa>(callTx);
    }

    /// <summary>
    /// Execute mechanic `Bet`
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="instanceId"></param>
    /// <returns></returns>
    public async Task<MxResultBet> ExecBet(NfaClassId classId, NfaInstanceId instanceId)
    {
        // Construct call payload
        var organizationId = client.Game.Address;
        var callTx = client.api.Tx.Mechanics.ExecBet(organizationId, classId, instanceId);
        return await SubmitMx<MxResultBet>(callTx);
    }

    /// <summary>
    /// Process network events and return mechanic result or raise error
    /// </summary>
    /// <param name="events"></param>
    private static TResult MxResultFromEvents<TResult>(MxId mxId, ExtrinsicEvents events) where TResult : MxResult, new()
    {
        // Try to find event with mechanisc execution result
        foreach (var evr in events)
        {
            var ev = evr.Event;
            if (ev.Value == Api.Types.FinalbiomeNodeRuntime.InnerEvent.Mechanics)
            {
                Api.Types.PalletMechanics.Pallet.Event eventData = (Api.Types.PalletMechanics.Pallet.Event)ev.Value2;
                switch (eventData.Value)
                {
                    case Api.Types.PalletMechanics.Pallet.InnerEvent.Finished:
                        {
                            var data = (FinalBiome.Api.Types.PalletMechanics.Pallet.EventFinished)eventData.Value2;
                            // skip if the id of the mechanics isn't our
                            if (!(data.Id.Value == mxId.nonce && Enumerable.SequenceEqual(data.Owner.Bytes, mxId.gamerAccount.Bytes))) break;
                            return new TResult()
                            {
                                Id = mxId,
                                Status = ResultStatus.Finished,
                                ResultRaw = data.Result.Value!
                            };
                        }
                    case Api.Types.PalletMechanics.Pallet.InnerEvent.Stopped:
                        {
                            var data = (FinalBiome.Api.Types.PalletMechanics.Pallet.EventStopped)eventData.Value2;
                            // skip if the id of the mechanics isn't our
                            if (!(data.Id == mxId.nonce && Enumerable.SequenceEqual(data.Owner.Bytes, mxId.gamerAccount.Bytes))) break;
                            return new TResult()
                            {
                                Id = mxId,
                                Status = ResultStatus.Stopped,
                                ReasonRaw = data.Reason
                            };
                        }
                    default:
                        throw new Exception($"Unknown mechanics event: {eventData.Value}");
                }
            }
        }
        throw new Exception($"Succesfull event for mechanics {mxId} is not found");
    }

    /// <summary>
    /// Get actual nonce from the network
    /// </summary>
    /// <param name="client"></param>
    /// <returns></returns>
    private static async Task<ulong> FetchNonce(Client client)
    {
        var accountNonce = await client.api.Rpc.SystemAccountNextIndex(client.Auth.UserAddress);
        return accountNonce;
    }

    /// <summary>
    /// Submit constructed mechanics and return result of execution.
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<TResult> SubmitMx<TResult>(TxPayload payload) where TResult : MxResult, new()
    {
        BaseExtrinsicParamsBuilder<PlainTip> otherParams = BaseExtrinsicParamsBuilder<PlainTip>.Default();
        var subExt = client.api.Tx.CreateSignedWithNonce(payload, signer, accountNonce, otherParams);
        var txProgress = await subExt.SubmitAndWatch();
        accountNonce++;
        var txInBlock = await txProgress.WaitForInBlock();
        // the next WaitForSuccess method can throw an ExtrinsicFailedException
        // TODO: wrap into more convenient MechanicFailedException
        var events = await txInBlock.WaitForSuccess();
        // init id of mechanic
        // this place of mx id initialization is not error. On the network, creation of id happends after increasing the nonce.
        MxId mxId = new(this.client.Auth.GamerAccount, accountNonce);

        return MxResultFromEvents<TResult>(mxId, events);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
