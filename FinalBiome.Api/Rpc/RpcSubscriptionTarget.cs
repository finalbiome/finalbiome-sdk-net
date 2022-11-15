using System;
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
        readonly Dictionary<string, ISubscription> subscriptions = new Dictionary<string, ISubscription>();

        /// <summary>
        /// Store subscription for future call
        /// </summary>
        /// <param name="subscription"></param>
        public void AddSubscription(ISubscription subscription)
        {
            this.subscriptions.Add(subscription.Id, subscription);
        }

        /// <summary>
        /// Drop subscroption from listener
        /// </summary>
        /// <param name="subscription"></param>
        public void RemoveSubscription(ISubscription subscription)
        {
            this.subscriptions.Remove(subscription.Id);
        }

        /// <summary>
        /// Notify a subscriber
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="subId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private async Task NotifySubscriber<TData>(string subId, TData data)
        {
            Subscription<TData> subscribtion = (Subscription<TData>)subscriptions[subId];
            await subscribtion.PostNewMessage(data);
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
            await NotifySubscriber<Header>(subscription, result);
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
            await NotifySubscriber<Header>(subscription, result);
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
            await NotifySubscriber<Header>(subscription, result);
        }
    }
}

