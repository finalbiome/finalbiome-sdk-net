
using FinalBiome.Api.Rpc;

namespace FinalBiome.Api.Blocks;

/// <summary>
/// The body of a block.
/// </summary>
public class BlockBody
{
    readonly ChainBlockResponse details;
    readonly Client client;
    readonly CachedEvents cachedEvents;

    public BlockBody(Client client,
                     ChainBlockResponse details,
                     CachedEvents cachedEvents)
    {
        this.client = client;
        this.details = details;
        this.cachedEvents = cachedEvents;
    }

    /// <summary>
    /// Returns an iterator over the extrinsics in the block body.
    /// </summary>
    public IEnumerable<Extrinsic> Extrinsics()
    {
        var extrinsics = this.details.Block.Extrinsics;
        return extrinsics.Value.Select((extrinsic, idx) => new FinalBiome.Api.Blocks.Extrinsic(
                    idx,
                    extrinsic,
                    client,
                    this.details.Block.Header.Hash(),
                    this.cachedEvents
                ));
    }
}

