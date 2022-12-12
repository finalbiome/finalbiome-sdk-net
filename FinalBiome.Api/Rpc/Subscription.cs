using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace FinalBiome.Api.Rpc;

public interface ISubscription
{
    public string Id { get; }
}

public class Subscription<TResult> : ISubscription
{
    readonly BufferBlock<TResult> buffer;
    readonly CancellationToken cancellationToken;
    public string Id { get; internal set; }
    /// <summary>
    /// Subscribtion of the RPC request
    /// </summary>
    public string Sub { get; internal set; }
    /// <summary>
    /// Parameters of the RPC request
    /// </summary>
    public object[] Parameters { get; internal set; }
    /// <summary>
    /// Unsubscribtion of the RPC request
    /// </summary>
    public string Unsub { get; internal set; }

    public Subscription(string subscribtionId, string sub, object[] parameters, string unsub, CancellationToken cancellationToken)
    {
        this.cancellationToken = cancellationToken;
        buffer = new BufferBlock<TResult>(
            new DataflowBlockOptions
            {
                CancellationToken = cancellationToken
            });
        Id = subscribtionId;
        Sub = sub;
        Parameters = parameters;
        Unsub = unsub;
    }

    /// <summary>
    /// Returns data enumerator
    /// </summary>
    /// <returns></returns>
    public async IAsyncEnumerable<TResult> data([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        try {
            while (await buffer.OutputAvailableAsync(this.cancellationToken))
            {
                yield return await buffer.ReceiveAsync<TResult>(this.cancellationToken);
            }
        } finally {}
    }

    /// <summary>
    /// Post new message for subscriber.
    /// </summary>
    /// <param name="subscribtionId"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    internal async Task PostNewMessage(TResult data)
    {
        await buffer.SendAsync(data);
    }

    internal void Unsubscribe()
    {
        buffer.Complete();
    }

}

