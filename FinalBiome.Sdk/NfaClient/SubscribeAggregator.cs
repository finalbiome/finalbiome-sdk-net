using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using FinalBiome.Api.Extensions;
using FinalBiome.Api.Storage;
using FinalBiome.Api.Types;

[assembly: InternalsVisibleTo("FinalBiome.Sdk.Test")]
namespace FinalBiome.Sdk;
using StorageKey = List<byte>;

/// <summary>
/// The aggregator of all storage subscriptions with defined type.<br/> 
/// </summary>
/// 
/// There is a need to subscribe to multiple storage keys.
/// In this case, the set of keys changes over time.
/// This class provides aggregation of subscriptions as the set of keys changes.
/// When adding a new key, a new task is created with a subscription to this key.
/// If the number of active tasks exceeds the set threshold, they are aggregated
/// into one common subscription. This reduces the overhead of maintaining an unlimited number
/// of background tasks.
/// 
/// Keys can be added or removed.
/// Removing a key requires canceling the corresponding subscription and stopping the task
/// in which the given subscription is running.
/// There may be other subscriptions in this task, which will require all subscriptions
/// to be resubscribed. And since this is a resource intensive task, it doesn't happen until the need for subscription aggregation.
/// That is, if there is a need to unsubscribe, it is performed in a separate task,
/// the key is removed from the list of keys for subscription, and any events that have come
/// about changing the value for this key will be ignored.
/// When and if subscriptions are aggregated, this key will not be included in the new
/// aggregated subscription.
internal class SubscribeAggregator<TResult> : IDisposable where TResult : Codec, new()
{
    /// <summary>
    /// Count of tasks after which subscriptions are aggregated.
    /// </summary>
    readonly uint tasksLimit = 5;
    readonly Client client;

    /// <summary>
    /// An event that occurs when a value in the store has been changed
    /// </summary>
    public event EventHandler<StorageChangedEventArgs<TResult>>? StorageChanged;

    /// <summary>
    /// Contains storage keys that are of interest to the initiator.
    /// We use the fake dict because we need the ability to remove specific element.
    /// 
    /// Note: Key in this dictionary we store as the hex string for better usability.
    /// </summary>
    /// <returns></returns>
    readonly ConcurrentDictionary<string, StorageKey> activeStorageKeys = new();

    /// <summary>
    /// Active subscriptions tasks
    /// </summary>
    /// <returns></returns>
    readonly ConcurrentBag<Task> subTasks = new();

    /// <summary>
    /// Cancellation token for all subscription tasks if we need to stop them internally.
    /// </summary>
    /// <returns></returns>
    CancellationTokenSource reSubscriberCancellationTokenSource;

    /// <summary>
    /// Cancellation token for all subscription tasks if need to stop all them externally.
    /// </summary>
    /// <returns></returns>
    readonly CancellationToken externalCancellationToken;

    /// <summary>
    /// Linked cancellation token for the ability to cancel subscription for internal purposes (re-subscription) and by initiator.
    /// </summary>
    /// <returns></returns>
    CancellationTokenSource linkedCancellationTokenSource;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    /// <param name="tasksLimit">Maximum number of concurrent subscriptions</param>
    public SubscribeAggregator(Client client, uint tasksLimit, CancellationToken cancellationToken)
    {
        this.client = client;
        this.tasksLimit = tasksLimit;
        this.externalCancellationToken = cancellationToken;
        this.reSubscriberCancellationTokenSource = new();
        this.linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(reSubscriberCancellationTokenSource.Token, this.externalCancellationToken);
    }

    /// <summary>
    /// Subscribe to changes at given address.
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public async Task Subscribe(StorageAddress address)
    {
        await Subscribe(new StorageAddress[] { address });
    }
    /// <summary>
    /// Subscribe on given addresses.
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public async Task Subscribe(IEnumerable<StorageAddress> addresses)
    {
        // filter already subscripted keys
        var keys = AddressesToStorageKeys(addresses).Where(key => !activeStorageKeys.ContainsKey(key.ToHex())).ToList();
        // nothing to do if no new keys
        if (!keys.Any()) return;
        // add new keys to the active keys
        foreach (var key in keys) activeStorageKeys.TryAdd(key.ToHex(), key);
        // if we have not exceeded the limit of simultaneously running tasks, we create a new one.
        // Otherwise, we perform a full re-subscription (aggregation of subscriptions).
        if (subTasks.Count < tasksLimit)
        {
            // create new task
            CreateNewSubscriptionTask(keys);
        }
        else
        {
            // aggregate subscriptions into the one
            await ReSubscribe();
        }
    }
    /// <summary>
    /// Unsubscribe from changes at given address.
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public void Unsubscribe(StorageAddress address)
    {
        Unsubscribe(new StorageAddress[] { address });
    }
    /// <summary>
    /// Unsubscribe from changes at given addresses.
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public void Unsubscribe(IEnumerable<StorageAddress> addresses)
    {
        // here we remove the key from activeStorageKeys
        foreach (var key in AddressesToStorageKeys(addresses)) activeStorageKeys.TryRemove(key.ToHex(), out StorageKey _);
        // and do nothing more. We ingnore any events for removed keys and not resubscribe in that cases because it's over complicated.
        // resubscription will clean this unnecessary keys.
    }

    void OnStorageChangedEvent(StorageChangedEventArgs<TResult> e)
    {
        StorageChanged?.Invoke(this, e);
    }

    /// <summary>
    /// The task which subscribes to given storage keys and listens to the change.
    /// When a change occurs, raises an event.
    /// </summary>
    /// <param name="storageKeys"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    async Task SubscribeAndListen(IEnumerable<StorageKey> storageKeys, CancellationToken cancellationToken)
    {
        // create subscription for all storage keys
        var sub = await client.api.Rpc.SubscribeStorage(storageKeys, cancellationToken);

        // listen new changes and raise events
        try
        {
            await foreach (var changeSet in sub.data(cancellationToken))
            {
                foreach (var change in changeSet.Changes)
                {
                    var key = change.StorageKey;
                    // if the key still exists in the active keys, then send event about changes
                    if (activeStorageKeys.ContainsKey(key.ToHex()))
                    {
                        if (change.StorageValue is not null)
                        {
                            var valueEncoded = change.StorageValue;
                            // decodes value
                            TResult value = new();
                            value.Init(valueEncoded);
                            // raise the event about changes
                            OnStorageChangedEvent(new StorageChangedEventArgs<TResult>(key, value));
                        }
                        else
                        {
                            // the asset doesn't exist and/or has been destroyed
                            OnStorageChangedEvent(new StorageChangedEventArgs<TResult>(key, null));
                        }
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            //
        }
        // from listen loop we exit only if cancellation occurs
        // unsubscribe from subscription on the network
        await client.api.Rpc.Unsubscribe(sub);
    }

    /// <summary>
    /// Re-subscribe of all subscriptions.
    /// Unsubscribe of all active subscriptions and subscribe only on stogage keys 
    /// existing in the activeStorageKeys
    /// </summary>
    /// <returns></returns>
    async Task ReSubscribe()
    {
        // 1. unsubscribe from all subscriptions by cancellation
        reSubscriberCancellationTokenSource.Cancel();
        // wait while all subscription tasks are done.
        try
        {
            await Task.WhenAll(subTasks.ToArray());
        }
        catch (OperationCanceledException) // redutant. Tasks completed execution successfully with no aly exceptions. 
        {
            // all tasks was finished
        }
        finally
        {
            reSubscriberCancellationTokenSource.Dispose();
            reSubscriberCancellationTokenSource = new();
            linkedCancellationTokenSource.Dispose();
            linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(reSubscriberCancellationTokenSource.Token, externalCancellationToken);
        }
        subTasks.Clear();
        // 2. subscribe on all keys at once
        CreateNewSubscriptionTask(activeStorageKeys.Values);
    }

    /// <summary>
    /// Create new task and add it into the tasks bag
    /// </summary>
    /// <param name="storageKeys"></param>
    /// <param name="externalCancellationToken"></param>
    void CreateNewSubscriptionTask(IEnumerable<StorageKey> storageKeys)
    {
        var t = Task.Run(async () => await SubscribeAndListen(storageKeys, linkedCancellationTokenSource.Token), linkedCancellationTokenSource.Token);
        subTasks.Add(t);
    }

    /// <summary>
    /// Transform Storage Addresses to list of Storage Keys
    /// </summary>
    /// <param name="addresses"></param>
    /// <returns></returns>
    static IEnumerable<StorageKey> AddressesToStorageKeys(IEnumerable<StorageAddress> addresses)
    {
        return addresses.Select(a => a.ToBytes());
    }

    public void Dispose()
    {
        if (linkedCancellationTokenSource is not null && linkedCancellationTokenSource.Token.CanBeCanceled) linkedCancellationTokenSource.Cancel();
        linkedCancellationTokenSource?.Dispose();
        reSubscriberCancellationTokenSource?.Dispose();
    }
}

/// <summary>
/// Event args of changing storage on some address
/// </summary>
public class StorageChangedEventArgs<TResult> : EventArgs where TResult : Codec, new()
{
    /// <summary>
    /// The address of the store where the changes occurred.
    /// </summary>
    /// <value></value>
    public StorageKey Key { get; internal set; }
    /// <summary>
    /// New value form storage.
    /// If it's null, the asset doesn't exist and/or has been destroyed.
    /// </summary>
    /// <value></value>
    public TResult? Value { get; internal set; }

    public StorageChangedEventArgs(StorageKey key, TResult? value)
    {
        Key = key;
        Value = value;
    }
}
