using System;
using FinalBiome.Api.Rpc.Types;
using FinalBiome.Api.Types;
using StreamJsonRpc;

namespace FinalBiome.Api.Rpc
{
    public class RpcSubscriptionTarget
    {
        /// <summary>
        /// Hold all active subscriptions
        /// </summary>
        /// 
        readonly Dictionary<string, ISubscription> subscriptions = new();

        /// <summary>
        /// Contains responses that are returned from the server, but the subscription with the given ID has not yet been initialized.
        /// </summary>
        /// <returns></returns>
        readonly Dictionary<string, List<object>> pendingResponses = new();
        /// <summary>
        /// Store subscription for future call
        /// </summary>
        /// <param name="subscription"></param>
        public async Task AddSubscription<TData>(ISubscription subscription)
        {
            this.subscriptions.Add(subscription.Id, subscription);
            // checks if we have pending responses. If yes, sends data to subscribers.
            if (pendingResponses.Remove(subscription.Id, out var responses))
            {
                foreach (var resp in responses)
                {
                    await ((Subscription<TData>)subscription).PostNewMessage((TData)resp).ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Drop subscription from listener
        /// </summary>
        /// <param name="subscription"></param>
        public void RemoveSubscription(ISubscription subscription)
        {
            this.subscriptions.Remove(subscription.Id);
        }

        /// <summary>
        /// Determines whether the listener contains the specified subscription.
        /// </summary>
        /// <param name="subscription"></param>
        /// <returns></returns>
        public bool SubscriptionExists(ISubscription subscription)
        {
            return this.subscriptions.ContainsKey(subscription.Id);
        }

        /// <summary>
        /// Notify a subscriber
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="subId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task NotifySubscriber<TData>(string subId, TData data) where TData : notnull
        {
            // Sometimes the response from the server is returned before the subscription is initialized.
            // If the subscription is not in the list of subscriptions,
            // we store the response in pendingResponses and send it to the subscribers
            // after the subscription is initialized.
            if (subscriptions.TryGetValue(subId, out ISubscription? value))
            {
                Subscription<TData> subscription = (Subscription<TData>)value;
                await subscription.PostNewMessage(data).ConfigureAwait(false);
            }
            else
            {
                if (!pendingResponses.ContainsKey(subId))
                {
                    pendingResponses.Add(subId, new());
                }
                if (pendingResponses.TryGetValue(subId, out List<object>? responses))
                {
                    responses.Add(data);
                }
            }
        }
        /// <summary>
        /// Response as subscription for all block headers (new blocks and finalized blocks).<br/>
        /// <see cref="https://github.com/w3f/PSPs/blob/master/PSPs/drafts/psp-6.md#196-chain_subscribeallheads-pubsub"/>
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [JsonRpcMethod("chain_allHead")]
        public async Task OnAllBlock(string subscription, Header result)
        {
            await NotifySubscriber<Header>(subscription, result).ConfigureAwait(false);
        }
        /// <summary>
        /// Response as Subscription for new block headers.<br/>
        /// <see cref="https://github.com/w3f/PSPs/blob/master/PSPs/drafts/psp-6.md#198-chain_subscribenewheads-pubsub"/>
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [JsonRpcMethod("chain_newHead")]
        public async Task OnNewBlock(string subscription, Header result)
        {
            await NotifySubscriber<Header>(subscription, result).ConfigureAwait(false);
        }
        /// <summary>
        /// Response as Subscription for finalized block headers.<br/>
        /// <see cref="https://github.com/w3f/PSPs/blob/master/PSPs/drafts/psp-6.md#1910-chain_subscribefinalizedheads-pubsub"/>
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [JsonRpcMethod("chain_finalizedHead")]
        public async Task OnFinalizedBlock(string subscription, Header result)
        {
            await NotifySubscriber<Header>(subscription, result).ConfigureAwait(false);
        }
        /// <summary>
        /// Response as Subscription for extrinsic updates
        /// <see cref="https://github.com/w3f/PSPs/blob/master/PSPs/drafts/psp-6.md#189-author_submitandwatchextrinsic-pubsub"/>
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [JsonRpcMethod("author_extrinsicUpdate")]
        public async Task OnExtrinsicUpdate(string subscription, SubstrateTxStatus result)
        {
            await NotifySubscriber<SubstrateTxStatus>(subscription, result).ConfigureAwait(false);
        }
        /// <summary>
        /// Response as Subscription for each block which changes the specified storage keys. If none are specified, then it creates a message for every block.
        /// <see cref="https://github.com/w3f/PSPs/blob/master/PSPs/drafts/psp-6.md#11115-state_subscribestorage-pubsub"/>
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        [JsonRpcMethod("state_storage")]
        public async Task OnStorageChange(string subscription, StorageChangeSet result)
        {
            await NotifySubscriber<StorageChangeSet>(subscription, result).ConfigureAwait(false);
        }
    }
}

