using System;
using System.Net.WebSockets;
using FinalBiome.Api.Rpc.JsonConverters;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using StreamJsonRpc;

namespace FinalBiome.Api.Rpc;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class RpcClient
{
    readonly ClientWebSocket ws;
    readonly JsonRpc rpc;
    readonly RpcSubscriptionTarget subscriptionTarget;

    RpcClient(ClientWebSocket ws, JsonRpc rpc, RpcSubscriptionTarget subscriptionTarget)
    {
        this.ws = ws;
        this.rpc = rpc;
        this.subscriptionTarget = subscriptionTarget;
    }

    /// <summary>
    /// Build WS RPC client from URL
    /// </summary>
    internal static async Task<RpcClient> Build(Uri url)
    {
        ClientWebSocket ws = new();
        await ws.ConnectAsync(url, CancellationToken.None);
        JsonRpc rpc = new(new WebSocketMessageHandler(ws, messageFormatter()));
        RpcSubscriptionTarget subscriptionTarget = new();
        rpc.AddLocalRpcTarget(subscriptionTarget, new JsonRpcTargetOptions { AllowNonPublicInvocation = false });
        rpc.StartListening();
        return new RpcClient(ws, rpc, subscriptionTarget);
    }

    static JsonMessageFormatter messageFormatter()
    {
        var messageFormatter = new JsonMessageFormatter();
        // adding converters
        messageFormatter.JsonSerializer.Converters.Add(new PrimitiveCodecTypeConverter<U8>());
        messageFormatter.JsonSerializer.Converters.Add(new PrimitiveCodecTypeConverter<U16>());
        messageFormatter.JsonSerializer.Converters.Add(new PrimitiveCodecTypeConverter<U32>());
        messageFormatter.JsonSerializer.Converters.Add(new PrimitiveCodecTypeConverter<U64>());
        messageFormatter.JsonSerializer.Converters.Add(new PrimitiveCodecTypeConverter<Hash>());
        messageFormatter.JsonSerializer.Converters.Add(new HeaderJsonConverter());
        messageFormatter.JsonSerializer.Converters.Add(new ChainBlockResponseJsonConverter());
        messageFormatter.JsonSerializer.Converters.Add(new ChainBlockJsonConverter());
        messageFormatter.JsonSerializer.Converters.Add(new SubstrateTxStatusJsonConverter());
        messageFormatter.JsonSerializer.Converters.Add(new StorageChangeSetJsonConverter());

        return messageFormatter;
    }

    /// <summary>
    /// Make an RPC request, given a method name and some parameters.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="method"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public async Task<TResult> Request<TResult>(string method, object[] parameters)
    {
        return await rpc.InvokeWithParameterObjectAsync<TResult>(method, parameters);
    }

    /// <summary>
    /// Subscribe to an RPC endpoint, providing the parameters and the method to call to
    /// unsubscribe from it again.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="sub"></param>
    /// <param name="parameters"></param>
    /// <param name="unsub"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Subscription<TResult>> Subscribe<TResult>(string sub, object[] parameters, string unsub, CancellationToken? cancellationToken = null) // where TResult : Codec
    {
        cancellationToken ??= CancellationToken.None;
        // Subscribe on events
        string subId = await Request<string>(sub, parameters);
        // Create subscription instance
        Subscription<TResult> subscription = new(subId, sub, parameters, unsub, (CancellationToken)cancellationToken);
        // Add to list
        this.subscriptionTarget.AddSubscription(subscription);

        return subscription;
    }

    /// <summary>
    /// Unsubscrinbe from RPC enpoint events
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="subscription"></param>
    /// <param name="clien"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    internal async Task Unsubscribe<TResult>(Subscription<TResult> subscription)
    {
        if (subscriptionTarget.SubscriptionExists(subscription))
        {
            string subId = subscription.Id;
            string _ = await Request<string>(subscription.Unsub, new object[] { subId });
            subscription.Unsubscribe();
            this.subscriptionTarget.RemoveSubscription(subscription);
        }
    }

#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CA1825
    internal static object[] RpcParams()
    {
        return new object[] { };
    }

    internal static object[] RpcParams<T>(T t)
    {
        return new object[] { t };
    }

    internal static object[] RpcParams<T0, T1>(T0 t0, T1 t1)
    {
        return new object[] { t0, t1 };
    }

    internal static object[] RpcParams<T0, T1, T2>(T0 t0, T1 t1, T2 t2)
    {
        return new object[] { t0, t1, t2 };
    }

    internal static object[] RpcParams<T0, T1, T2, T3>(T0 t0, T1 t1, T2 t2, T3 t3)
    {
        return new object[] { t0, t1, t2, t3 };
    }
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CA1825
}

