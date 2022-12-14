namespace FinalBiome.Sdk;

using FinalBiome.Api.Types.PalletSupport;
using FinalBiome.Api.Types.Primitive;
using NfaClassId = UInt32;
using NfaInstanceId = UInt32;
/// <summary>
/// Listener of the network events for subscription on new nfa assets.
/// </summary>
/// if the user becomes the owner of a new asset, it is necessary to notify the sdk about this and subscribe to its changes.
/// This behavior should be redone after the release of RPC about new assets.
internal class NetworkEventsListener : IDisposable
{
    readonly Client client;

    /// <summary>
    /// Subscriber task about avents on the network.
    /// </summary>
    Task? subscriberTask;
    /// <summary>
    /// Cancellation token for subscriberTask
    /// </summary>
    /// <returns></returns>
    CancellationTokenSource subscriberCancellationTokenSource;
    /// <summary>
    /// A delegate type that will invoke when a new Nfa asset has been issued to the user.
    /// </summary>
    /// <param name="classId"></param>
    /// <param name="instanceId"></param>
    /// <returns></returns>
    public delegate Task OnIssuedAsset(NfaClassId classId, NfaInstanceId instanceId);
    /// <summary>
    /// An event that occurs when a new Nfa asset has been issued to the user.
    /// </summary>
    public OnIssuedAsset? NfaIssued;

    /// <summary>
    /// A delegate that will invoke when active mechanics has been dropped by timeout
    /// </summary>
    /// <param name="mechanicId"></param>
    /// <returns></returns>
    public delegate Task OnDroppedMechanics(GamerAccount gamerAccount, U32 nonce);

    /// <summary>
    /// An event that occurs when active mechanics has been dropped by timeout
    /// </summary>
    public OnDroppedMechanics? MechanicsDropped;

    public NetworkEventsListener(Client client)
    {
        this.client = client;
        this.subscriberCancellationTokenSource = new();

        this.client.Auth.StateChanged += HandleUserStateChangedEvent;
    }

    /// <summary>
    /// Subscribe to all events on the network.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    async Task SubscribeToEvents(CancellationToken cancellationToken)
    {
        var sub = client.api.Storage.System.Events().Subscribe(cancellationToken);
        try
        {
            await foreach (var eventRecords in sub.ConfigureAwait(false))
            {
                if (eventRecords is not null && client.Auth.UserAddress is not null)
                foreach (var eventRecord in eventRecords.Value)
                {
                    var ev = eventRecord.Event;

                        #region Events filtering
                        await Task.WhenAll(
                            // find event about issuance of the nfa instance to user
                            ProcessEventNfaIssued(ev),
                            // find event about dropped mechanics by timeout
                            ProcessEventMechanicsDropped(ev)
                        ).ConfigureAwait(false);
                        #endregion
                    }
            }
        }
        catch (TaskCanceledException) { }
    }

    /// <summary>
    /// Process event and invoke event if Nfa was issued
    /// </summary>
    /// <param name="ev"></param>
    /// <returns></returns>
    async Task ProcessEventNfaIssued(Api.Types.FinalbiomeNodeRuntime.Event ev)
    {
        // find events about issuance of the nfa instance to user
        if (ev.Value == Api.Types.FinalbiomeNodeRuntime.InnerEvent.NonFungibleAssets)
        {
            var evData = ev.Value2 as Api.Types.PalletNonFungibleAssets.Pallet.Event;
            if (evData?.Value == Api.Types.PalletNonFungibleAssets.Pallet.InnerEvent.Issued)
            {
                var issuedData = evData.Value2 as Api.Types.PalletNonFungibleAssets.Pallet.EventIssued;
                // get a nfa issued only for the current user.
                if (issuedData is not null && Enumerable.SequenceEqual(issuedData.Owner.Bytes, client.Auth.UserAddress.Bytes))
                {
                    // send event about it
                    // OnNfaIssuedEvent(new NfaInstanceIssuedEventArgs(issuedData.ClassId, issuedData.AssetId));
                    if (NfaIssued is not null)
                        await NfaIssued(issuedData.ClassId, issuedData.AssetId).ConfigureAwait(false);
                }
            }
        }
    }

    /// <summary>
    /// Process event and invoke event if mechanics was dropped by timeout
    /// </summary>
    /// <param name="ev"></param>
    /// <returns></returns>
    async Task ProcessEventMechanicsDropped(Api.Types.FinalbiomeNodeRuntime.Event ev)
    {
        // find events about mechanics dropped
        if (ev.Value == Api.Types.FinalbiomeNodeRuntime.InnerEvent.Mechanics)
        {
            var evData = ev.Value2 as FinalBiome.Api.Types.PalletMechanics.Pallet.Event;
            if (evData?.Value == FinalBiome.Api.Types.PalletMechanics.Pallet.InnerEvent.DroppedByTimeout)
            {
                var droppedData = evData.Value2 as FinalBiome.Api.Types.PalletMechanics.Pallet.EventDroppedByTimeout;
                // get a mechanic events only for the current user.
                if (droppedData is not null &&
                    Enumerable.SequenceEqual(droppedData.Owner.AccountId.Bytes, client.Auth.UserAddress.Bytes) &&
                    Enumerable.SequenceEqual(droppedData.Owner.OrganizationId.Bytes, client.Game.Address.Bytes)
                )
                {
                    // send event about it
                    if (MechanicsDropped is not null)
                        await MechanicsDropped(droppedData.Owner, droppedData.Id).ConfigureAwait(false);
                }
            }
        }
    }

    /// <summary>
    /// Create subscriber task to watch on all network events.<br/>
    /// If task already exists, restart them.
    /// </summary>
    /// <returns></returns>
    public async Task StartNetworkEventsListener()
    {
        if (client.Auth.UserAddress is null) throw new Exception("User not set");
        if (subscriberCancellationTokenSource.IsCancellationRequested) return;
        await StopNetworkEventsListener().ConfigureAwait(false);
        CancellationToken cancellationToken = subscriberCancellationTokenSource.Token;
        subscriberTask = Task.Run(async () => await SubscribeToEvents(cancellationToken), cancellationToken);
    }
    
    /// <summary>
    /// Stop subscription if exists.
    /// </summary>
    /// <returns></returns>
    public async Task StopNetworkEventsListener()
    {
        if (subscriberCancellationTokenSource.IsCancellationRequested) return;
        if (subscriberTask is not null) 
        {
            // cancel previous subscriber task
            subscriberCancellationTokenSource.Cancel();
            try
            {
                #if NETSTANDARD2_1
                subscriberTask.Wait(TimeSpan.FromSeconds(10));
                await Task.Yield();
                #else
                await subscriberTask.WaitAsync(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
                #endif
            }
            catch (OperationCanceledException)
            {}
            finally
            {
                subscriberCancellationTokenSource.Dispose();
                // create new token source
                subscriberCancellationTokenSource = new();
            }
        }
    }

    /// <summary>
    /// Handler to changes of the user state for subscribing to network events.
    /// </summary>
    /// <param name="isLogged"></param>
    /// <returns></returns>
    async Task HandleUserStateChangedEvent(bool isLogged)
    {
        if (isLogged) {
            // here we need fetch and subscribe to network events
            await StartNetworkEventsListener().ConfigureAwait(false);
        }
        else
        {
            // here we need clean and unsubscribe from network events
            await StopNetworkEventsListener().ConfigureAwait(false);
        }
    }


    public void Dispose()
    {
        if (subscriberCancellationTokenSource is not null && !subscriberCancellationTokenSource.IsCancellationRequested) subscriberCancellationTokenSource.Cancel();
        subscriberCancellationTokenSource?.Dispose();
    }
}
