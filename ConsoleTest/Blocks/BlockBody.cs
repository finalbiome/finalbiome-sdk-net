using System;
namespace FinalBiome.Sdk.Blocks
{
    /// <summary>
    /// The body of a block.
    /// </summary>
    public class BlockBody
    {
        Ajuna.NetApi.Model.Rpc.ChainBlockResponse details;
        Client client;
        CachedEvents cachedEvents;

        public BlockBody(Client client,
                         Ajuna.NetApi.Model.Rpc.ChainBlockResponse details,
                         CachedEvents cachedEvents)
        {
            this.client = client;
            this.details = details;
            this.cachedEvents = cachedEvents;
        }

        /// <summary>
        /// Returns an iterator over the extrinsics in the block body.
        /// </summary>
        public IEnumerable<FinalBiome.Sdk.Blocks.Extrinsic> Extrinsics()
        {
            var extrinsics = this.details.Block.Extrinsics;
            int idx = 0;
            return extrinsics.Value.Select(extrinsic => new FinalBiome.Sdk.Blocks.Extrinsic(
                        idx++,
                        extrinsic,
                        client,
                        this.details.Block.Header.Hash(),
                        this.cachedEvents
                    ));


            //for (int idx = 0; idx < extrinsics.Length; idx++)
            //{
            //    yield return new FinalBiome.Sdk.Blocks.Extrinsic(
            //            idx,
            //            extrinsics[idx],
            //            client,
            //            this.details.Block.Header.Hash(),
            //            this.cachedEvents
            //        );;
            //}
        }
    }
}

