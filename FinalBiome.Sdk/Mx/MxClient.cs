using System.Collections.Concurrent;

namespace FinalBiome.Sdk;

using FinalBiome.Api.Blocks;
using FinalBiome.Api.Tx;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
using OfferId = UInt32;
using GamerAccount = Api.Types.PalletSupport.GamerAccount;
using FinalBiome.Api.Storage;
using StorageKey = List<byte>;
using Index = Api.Types.Primitive.U32;
using FinalBiome.Api.Types.PalletMechanics.Types;
using FinalBiome.Api.Extensions;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.PalletSupport;

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
    /// Root bytes for the mechanics storage of the mechanics module
    /// </summary>
    static readonly StorageKey RootBytesOfMechanicsStorage = new StaticStorageAddress("Mechanics", "Mechanics", new()).ToRootBytes();

    /// <summary>
    /// All current active mechanics.
    /// If mechanics is not finished, it is here.
    /// </summary>
    internal readonly ConcurrentDictionary<MxId, MechanicDetails> activeMechanics;

    /// <summary>
    /// Cancellation token for all subscriber tasks
    /// </summary>
    /// <returns></returns>
    readonly CancellationTokenSource subscriberCancellationTokenSource;
    /// <summary>
    /// Subscriber to active mechanics details
    /// </summary>
    readonly SubscribeAggregator<MechanicDetails> subscriberToMechanics;

    /// <summary>
    /// Event emitted when details of some active mechanics has been changed.
    /// </summary>
    public event EventHandler<MechanicsChangedEventArgs>? MechanicsChanged;
    /// <summary>
    /// Event emitted when some active mechanics was droped by timeout.
    /// </summary>
    public event EventHandler<MechanicsDroppedEventArgs>? MechanicsDropped;

    private MxClient(
        Client client, 
        PairSigner signer, 
        ulong accountNonce,
        CancellationTokenSource subscriberCancellationTokenSource,
        SubscribeAggregator<MechanicDetails> subscriberToMechanics
    )
    {
        this.client = client;
        this.signer = signer;
        this.accountNonce = accountNonce;
        this.activeMechanics = new();
        this.subscriberCancellationTokenSource = subscriberCancellationTokenSource;

        this.subscriberToMechanics = subscriberToMechanics;
        this.subscriberToMechanics.StorageChanged += SubscriberToMechanicsDetailsHandler;

        // listen network events about mechanics dropped by timeout
        this.client.Nfa.networkEventsListener.MechanicsDropped += MechanicsDroppedHandler;
    }

    internal static async Task<MxClient> Create(Client client, PairSigner signer)
    {
        var accountNonce = await FetchNonce(client).ConfigureAwait(false);

        // get from the network all active mechanics and subscribe to it
        List<StorageAddress> mxAddresses = new();
        await foreach (MxId mxId in FetchActiveMechanics(client).ConfigureAwait(false))
        {
            var addr = client.api.Storage.Mechanics.MechanicsGet(mxId.gamerAccount, (uint)mxId.nonce).Address; // TODO: change nonce to the u64 in the node
            mxAddresses.Add(addr);
        }
        CancellationTokenSource cts = new();
        SubscribeAggregator<MechanicDetails> subscriberToMechanics = new(client, tasksLimit: 5, cts.Token);
        await subscriberToMechanics.Subscribe(mxAddresses).ConfigureAwait(false);

        MxClient mxClient = new(client, signer, accountNonce, cts, subscriberToMechanics);
        return mxClient;
    }

    void SubscriberToMechanicsDetailsHandler(object? o, StorageChangedEventArgs<MechanicDetails> eventArgs)
    {
        // parse key into mechanics id
        MxId mxId = MxIdFromStorageKeyOfMehanics(RootBytesOfMechanicsStorage.Count, eventArgs.Key);

        if (eventArgs.Value is not null)
        {
            activeMechanics[mxId] = eventArgs.Value;
        }
        else
        {
            // instance was destroyed
            activeMechanics.TryRemove(mxId, out var _);
        }
        // emit event
        OnMechanicsChangedEvent(new MechanicsChangedEventArgs(mxId, eventArgs.Value));
    }

    /// <summary>
    /// Get from the network active users mechanics.
    /// </summary>
    /// <returns></returns>
    static async IAsyncEnumerable<MxId> FetchActiveMechanics(Client client)
    {
        // create the partial storage key of owned mechanics
        var queryKey = new StorageKey(RootBytesOfMechanicsStorage);
        var smKey = new StorageMapKey(client.Auth.GamerAccount, StorageHasher.Twox64Concat);
        smKey.ToBytes(ref queryKey);

        var partialKeyLength = RootBytesOfMechanicsStorage.Count;

        StorageKey? startKey = null;
        List<StorageKey>? keys;
        do
        {
            keys = await client.api.Storage.FetchKeys(queryKey, 10, startKey, null).ConfigureAwait(false);

            if (keys is not null && keys.Count != 0)
            {
                startKey = keys.Last();
                foreach (var key in keys)
                {
                    MxId mxId = MxIdFromStorageKeyOfMehanics(partialKeyLength, key);
                    yield return mxId;
                }
            }
        } while (keys is not null && keys.Count != 0);
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
        var payload = client.api.Tx.Mechanics.ExecBuyNfa(organizationId, classId, offerId);

        return await SubmitMx<MxResultBuyNfa>(payload).ConfigureAwait(false);
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
        var payload = client.api.Tx.Mechanics.ExecBet(organizationId, classId, instanceId);
        return await SubmitMx<MxResultBet>(payload).ConfigureAwait(false);
    }

    /// <summary>
    /// Make onboarding to the game.
    /// </summary>
    /// <returns></returns>
    public async Task OnboardToGame()
    {
        // if user is already onboarded, nothing to do
        if (client.Game.IsOnboarded is not null && (bool)client.Game.IsOnboarded) return;

        var payload = client.api.Tx.OrganizationIdentity.Onboarding(this.client.Game.Address);
        var _ = await Submit(payload).ConfigureAwait(false);
        client.Game.IsOnboarded = true;
    }

    /// <summary>
    /// Play new round for the Bet mechanics.
    /// </summary>
    /// <param name="mxId"></param>
    /// <returns></returns>
    public async Task<MxResultBet> UpgradeBet(MxId mxId)
    {
        // Construct call payload
        var organizationId = client.Game.Address;
        MechanicUpgradeData upgradeData = new();
        MechanicUpgradePayload upgradePayload = new();
        upgradePayload.Init(InnerMechanicUpgradePayload.Bet, new BaseVoid());
        upgradeData.Init(
            ((MechanicId)mxId).Encode()
            .Concat(upgradePayload.Encode())
            .ToArray()
        );
        var payload = client.api.Tx.Mechanics.Upgrade(organizationId, upgradeData);
        return await SubmitMx<MxResultBet>(payload, mxId).ConfigureAwait(false);
    }

    /// <summary>
    /// Process network events and return mechanic result or raise error
    /// </summary>
    /// <param name="events"></param>
    private async Task<TResult> MxResultFromEvents<TResult>(MxId mxId, ExtrinsicEvents events) where TResult : MxResult, new()
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
                            // this is the final status of the mechanics, so unsubscribe form changes and remove it from cache
                            if (activeMechanics.ContainsKey(mxId))
                            {
                                var addr = client.api.Storage.Mechanics.MechanicsGet(mxId.gamerAccount, (uint)mxId.nonce).Address; // TODO: change nonce to the u64 in the node
                                this.subscriberToMechanics.Unsubscribe(addr);
                            }

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
                            // this is not the final status of the mechanics. Subscribe to changes.
                            var addr = client.api.Storage.Mechanics.MechanicsGet(mxId.gamerAccount, (uint)mxId.nonce).Address; // TODO: change nonce to the u64 in the node
                            await this.subscriberToMechanics.Subscribe(addr).ConfigureAwait(false);

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
        var accountNonce = await client.api.Rpc.SystemAccountNextIndex(client.Auth.UserAddress).ConfigureAwait(false);;
        return accountNonce;
    }

    /// <summary>
    /// Submit transaction with respect to nonce and return success events.
    /// If nonce was wrong, nonce updates from the network and this call repeats.
    /// </summary>
    /// <param name="payload"></param>
    /// <param name="retries"></param>
    /// <returns></returns>
    private async Task<ExtrinsicEvents> Submit(TxPayload payload, uint? retries = null)
    {
        BaseExtrinsicParamsBuilder<PlainTip> otherParams = BaseExtrinsicParamsBuilder<PlainTip>.Default();
        var subExt = client.api.Tx.CreateSignedWithNonce(payload, signer, accountNonce, otherParams);
        try
        {
            var txProgress = await subExt.SubmitAndWatch().ConfigureAwait(false);
            accountNonce++;
            var txInBlock = await txProgress.WaitForInBlock().ConfigureAwait(false);
            // the next WaitForSuccess method can throw an ExtrinsicFailedException
            // TODO: wrap into more convenient MechanicFailedException
            ExtrinsicEvents? events = await txInBlock.WaitForSuccess().ConfigureAwait(false);
            return events;
        }
        catch (StreamJsonRpc.RemoteInvocationException e)
        {
            var failureReason = NetworkFailureParser.GetFailureReason(e);
            switch (failureReason)
            {
                case NetworkErrorReason.TransactionIsOutdated:
                    {
                        // suppose this happens if the local account's nonce is stale
                        // refresh nonce from the network and repeat request 
                        if (retries > 2) throw; // prevent infinite loop
                        this.accountNonce = await FetchNonce(client).ConfigureAwait(false);
                        retries = retries is null ? 1 : retries++;
                        return await Submit(payload, retries).ConfigureAwait(false);
                    }
                default:
                    throw NetworkFailureParser.WrapError(e);
            }
        }
    }

    /// <summary>
    /// Submit constructed mechanics and return result of execution.
    /// Mechanics id used for locate machanics events (by mechanics id).
    /// For the new mechanics, id will be created
    /// </summary>
    /// <param name="payload"></param>
    /// <returns></returns>
    private async Task<TResult> SubmitMx<TResult>(TxPayload payload, MxId? mxId = null) where TResult : MxResult, new()
    {
        ExtrinsicEvents events = await Submit(payload).ConfigureAwait(false);;
        // init id of mechanic if it doesn't exists.
        // this place of mx id initialization statement is not error. On the network, creation of id happends after increasing the nonce.
        mxId ??= new(client.Auth.GamerAccount, accountNonce);
        return await MxResultFromEvents<TResult>((MxId)mxId, events).ConfigureAwait(false);
    }

    /// <summary>
    /// Convert a storage key of Mechanics storage in the Mechanics module to the mechanics id.
    /// </summary>
    /// <param name="partialKeyLength"></param>
    /// <param name="storageKey"></param>
    /// <returns></returns>
    static MxId MxIdFromStorageKeyOfMehanics(int partialKeyLength, StorageKey storageKey)
    {
        // we know what the last part of key is Index(u32) with Twox64Concat hash.
        var bytes = storageKey.ToArray();
        // skip root key
        int pos = partialKeyLength;
        // skip hash of a class id (Twox64Concat)
        pos += 8;
        GamerAccount ga = new();
        ga.Decode(bytes, ref pos);
        // skip hash of a class id (Twox64Concat)
        pos += 8;
        Index nonce = Api.Types.Codec.Decode<Index>(bytes, ref pos);
        MxId id = new(ga, nonce);
        return id;
    }

    /// <summary>
    /// Handler of network events about mechanics dropped by timeout.
    /// </summary>
    /// <param name="gamerAccount"></param>
    /// <param name="nonce"></param>
    /// <returns></returns>
    async Task MechanicsDroppedHandler(GamerAccount gamerAccount, Index nonce)
    {
        // if some mechanics was dropped, we need to remove it from active mechanics and notify subscribers about it
        MxId mxId = new(gamerAccount, (uint)nonce);
        this.activeMechanics.TryRemove(mxId, out var _);

        OnMechanicsDroppedEvent(new (mxId));
        await Task.Yield();
    }
    void OnMechanicsChangedEvent(MechanicsChangedEventArgs e)
    {
        MechanicsChanged?.Invoke(this, e);
    }

    void OnMechanicsDroppedEvent(MechanicsDroppedEventArgs e)
    {
        MechanicsDropped?.Invoke(this, e);
    }

    public void Dispose()
    {
        if (subscriberCancellationTokenSource.Token.CanBeCanceled) subscriberCancellationTokenSource.Cancel();
        subscriberCancellationTokenSource.Dispose();
        subscriberToMechanics.Dispose();
        GC.SuppressFinalize(this);
    }
}
