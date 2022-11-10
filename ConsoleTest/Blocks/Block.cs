using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;

namespace FinalBiome.Sdk.Blocks
{
    /// <summary>
    /// A representation of a block.
    /// </summary>
    public class Block
    {
        Ajuna.NetApi.Model.Rpc.Header header;
        Client client;
        // Since we obtain the same events for every extrinsic, let's
        // cache them so that we only ever do that once
        CachedEvents cachedEvents;

        // A cache for our events so we don't fetch them more than once when
        // iterating over events for extrinsics.


        public Block(Ajuna.NetApi.Model.Rpc.Header header, Client client)
        {
            this.header = header;
            this.client = client;
            cachedEvents = new CachedEvents();
        }

        /// <summary>
        /// Return the block hash. (it is header hash)
        /// </summary>
        public Ajuna.NetApi.Model.Types.Base.Hash Hash => this.header.Hash();

        /// <summary>
        /// Return the block number.
        /// </summary>
        public BaseCom<U32> Number => this.header.Number;

        public Ajuna.NetApi.Model.Rpc.Header Header => this.header;

        /// <summary>
        /// Return the events associated with the block, fetching them from the node if necessary.
        /// </summary>
        /// <returns></returns>
        public Task<Events.Events> Events()
        {
            return this.cachedEvents.GetEvents(client, this.Hash);
        }

        /// <summary>
        /// Fetch and return the block body.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BlockHashNotFoundException"></exception>
        public async Task<BlockBody> Body()
        {
            var blockDetails = await client.client.Chain.GetBlockAsync(this.Hash);
            if (blockDetails.Block is null) throw new BlockHashNotFoundException(this.Hash);

            return new BlockBody(client, blockDetails, cachedEvents);
        }

    }
}

