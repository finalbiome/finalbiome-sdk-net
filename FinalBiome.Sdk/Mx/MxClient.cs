using FinalBiome.Api.Tx.Errors;
using FinalBiome.Api.Types;
using FinalBiome.Api;


namespace FinalBiome.Sdk;

using FinalBiome.Api.Blocks;
using FinalBiome.Api.Tx;
using FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId;
using FinalBiome.Api.Types.Primitive;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using OfferId = UInt32;
using Index = Api.Types.Primitive.U32;

/// <summary>
/// Client for access machnic execution and mechanics traction.
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
public class MxClient
{
    readonly Client client;

    /// <summary>
    /// Current nonce that can used for submitting Tx
    /// </summary>
    internal Index? accountNonce;

    private MxClient(Client client)
    {
        this.client = client;

        client.Auth.StateChanged += HandleUserStateChangedEvent;
    }

    internal static async Task<MxClient> Create(Client client)
    {
        return await Task.FromResult(new MxClient(client));
    }

    /// <summary>
    /// Execute mechanics `Buy NFA`.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="offerId"></param>
    /// <returns></returns>
    public async Task<MxResult> ExecBuyNfa(NfaClassId classId, OfferId offerId)
    {
        if (client.Auth.signer is null || accountNonce is null) throw new Exception("User not set");

        MxId mxId = new(client.Auth.UserAddress!, (U32)(accountNonce + 1));

        NonFungibleClassId nonFungibleClassId = new();
        nonFungibleClassId.Init(classId);
        U32 offerIdU32 = (U32)offerId;
        // Construct call payload
        var callTx = client.api.Tx.Mechanics.ExecBuyNfa(nonFungibleClassId, offerIdU32);

        BaseExtrinsicParamsBuilder<PlainTip> otherParams = BaseExtrinsicParamsBuilder<PlainTip>.Default();
        var subExt = client.api.Tx.CreateSignedWithNonce(callTx, client.Auth.signer, accountNonce, otherParams);
        var buyNfaProc = await subExt.SubmitAndWatch();

        var buyNfa = await buyNfaProc.WaitForInBlock();
        var events = await buyNfa.WaitForSuccess();

        return MxResultFromEvents(mxId, events);
    }

    /// <summary>
    /// Process network events and return mechanic result or raise error
    /// </summary>
    /// <param name="events"></param>
    private static MxResult MxResultFromEvents(MxId mxId, ExtrinsicEvents events)
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
                            if (!(data.Id.Value == mxId.nonce.Value && Enumerable.SequenceEqual(data.Owner.Bytes, mxId.accountId.Bytes))) break;
                            return new MxResult()
                            {
                                Id = mxId,
                                Status = ResultStatus.Finished,
                                Result = data.Result.Value
                            };
                        }
                    case Api.Types.PalletMechanics.Pallet.InnerEvent.Stopped:
                        {
                            var data = (FinalBiome.Api.Types.PalletMechanics.Pallet.EventStopped)eventData.Value2;
                            // skip if the id of the mechanics isn't our
                            if (!(data.Id == mxId.nonce && Enumerable.SequenceEqual(data.Owner.Bytes, mxId.accountId.Bytes))) break;
                            return new MxResult()
                            {
                                Id = mxId,
                                Status = ResultStatus.Stopped,
                                Reason = data.Reason
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
    /// Handler to changes of the user state for init account nonce.
    /// </summary>
    /// <param name="isLogged"></param>
    /// <returns></returns>
    async Task HandleUserStateChangedEvent(bool isLogged)
    {
        if (isLogged)
        {
            // get actual nonce from the network
            var accountNonce = await client.api.Rpc.SystemAccountNextIndex(client.Auth.UserAddress!);
            this.accountNonce = (U32)accountNonce;
        }
        else
        {
            this.accountNonce = null;
        }
    }
}
