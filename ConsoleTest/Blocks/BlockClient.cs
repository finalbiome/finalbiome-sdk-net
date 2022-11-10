using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;

namespace FinalBiome.Sdk.Blocks
{
    public class BlockClient
    {
        Client _client;

        public BlockClient(Client client)
        {
            this._client = client;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<Block> At(Hash? blockHash = null)
        {
            Hash hash;
            if (blockHash is not null) hash = blockHash;
            else
            {
                hash = await this._client.client.Chain.GetBlockHashAsync();
            }

            Header header = await _client.client.Chain.GetHeaderAsync(hash);
            if (header.Digest is null) throw new BlockHashNotFoundException(hash);

            return new Block(header, _client);
        }

        /// <summary>
        /// Subscribe to finalized blocks.
        /// </summary>
        /// <returns></returns>
        public async Task<string> SubscribeFinalized(Func<string, FinalBiome.Sdk.Blocks.Block, Task> callback)
        {
            // Fetch the last finalised block details immediately, so that we'll get
            // all blocks after this one.

            var lastFinalizedBlockHash = await _client.client.Chain.GetFinalizedHeadAsync();
            var lastFinalizedBlockHeader = await _client.client.Chain.GetHeaderAsync(lastFinalizedBlockHash);
            var lastFinalizedBlockNum = lastFinalizedBlockHeader.Number;

            Func<string, Header, Task> cb = async (subscriptionId, header) =>
            {
                FinalBiome.Sdk.Blocks.Block block = new Block(header, this._client);
                await callback(subscriptionId, block);
            };

            return await _client.client.Chain.SubscribeFinalizedHeadsAsync(cb);
            // TODO: Adjust the subscription stream to fill in any missing blocks.
        }
    }
}

