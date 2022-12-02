namespace FinalBiome.Sdk;
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
    /// An event that occurs when a new nFa asset has been issued to the user.
    /// </summary>
    public event EventHandler<NfaInstanceIssuedEventArgs>? NfaIssued;

    public NetworkEventsListener(Client client)
    {
        this.client = client;
        this.subscriberCancellationTokenSource = new();
    }

    /// <summary>
    /// Subscribe to all events on the network.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    async Task SubscribeToEvents(CancellationToken cancellationToken)
    {
        var sub = client.api.Storage.System.Events().Subscribe(cancellationToken);
        await foreach (var eventRecords in sub)
        {
            if (eventRecords is not null && client.Auth.UserAddress is not null)
            foreach (var eventRecord in eventRecords.Value)
            {
                var ev = eventRecord.Event;

                #region Events filtering
                // find events about issuance of the nfa instance to user
                if (ev.Value == Api.Types.FinalbiomeNodeRuntime.InnerEvent.NonFungibleAssets)
                {
                    var evData = ev.Value2 as Api.Types.PalletNonFungibleAssets.Pallet.Event;
                    if (evData?.Value == Api.Types.PalletNonFungibleAssets.Pallet.InnerEvent.Issued)
                    {
                        var issuedData = evData.Value2 as Api.Types.PalletNonFungibleAssets.Pallet.EventIssued;
                        // get a nfa issued only for the current user.
                        if (issuedData is not null && Enumerable.SequenceEqual(issuedData.Owner.Bytes,  client.Auth.UserAddress.Bytes))
                        {
                            // send event about it
                            OnNfaIssuedEvent(new NfaInstanceIssuedEventArgs(issuedData.ClassId, issuedData.AssetId));
                        }
                    }
                }
                #endregion
            }
        }
    }

    void OnNfaIssuedEvent(NfaInstanceIssuedEventArgs e)
    {
        NfaIssued?.Invoke(this, e);
    }

    /// <summary>
    /// Create subscriber task to watch on all network events.<br/>
    /// If task already exists, restart them.
    /// </summary>
    /// <returns></returns>
    public async Task StartNetworkEventsListener()
    {
        if (client.Auth.UserAddress is null) throw new Exception("User not set");
        if (subscriberCancellationTokenSource.Token.IsCancellationRequested) return;
        await StopNetworkEventsListener();
        CancellationToken cancellationToken = subscriberCancellationTokenSource.Token;
        subscriberTask = Task.Run(async () => await SubscribeToEvents(cancellationToken), cancellationToken);
    }
    
    /// <summary>
    /// Stop subscription if exists.
    /// </summary>
    /// <returns></returns>
    public async Task StopNetworkEventsListener()
    {
        if (subscriberCancellationTokenSource.Token.IsCancellationRequested) return;
        if (subscriberTask is not null) 
        {
            // cancel previous subscriber task
            subscriberCancellationTokenSource.Cancel();
            try
            {
                await subscriberTask.WaitAsync(TimeSpan.FromSeconds(10));
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

    public void Dispose()
    {
        if (subscriberCancellationTokenSource is not null && !subscriberCancellationTokenSource.IsCancellationRequested) subscriberCancellationTokenSource.Cancel();
        subscriberCancellationTokenSource?.Dispose();
    }
}

/// <summary>
/// Event args of issued Nfa instance
/// </summary>
internal class NfaInstanceIssuedEventArgs : EventArgs
{
    /// <summary>
    /// The class Id of the issued Nfa asset.
    /// </summary>
    public NfaClassId classId;

    /// <summary>
    /// The instance Id of the issued Nfa asset.
    /// </summary>
    public NfaInstanceId instanceId;

    public NfaInstanceIssuedEventArgs(uint classId, uint instanceId)
    {
        this.classId = classId;
        this.instanceId = instanceId;
    }
}
