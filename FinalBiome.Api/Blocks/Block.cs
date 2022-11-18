using FinalBiome.Api.Rpc;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Blocks;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
/// <summary>
/// A representation of a block.
/// </summary>
public class Block
{
    Header header;
    Client client;
    // Since we obtain the same events for every extrinsic, let's
    // cache them so that we only ever do that once
    CachedEvents cachedEvents;

    // A cache for our events so we don't fetch them more than once when
    // iterating over events for extrinsics.


    public Block(Header header, Client client)
    {
        this.header = header;
        this.client = client;
        cachedEvents = new CachedEvents();
    }

    /// <summary>
    /// Return the block hash. (it is header hash)
    /// </summary>
    public Hash Hash => this.header.Hash();

    /// <summary>
    /// Return the block number.
    /// </summary>
    public Compact<U32> Number => this.header.Number;

    /// <summary>
    /// Return the entire block header.
    /// </summary>
    public Header Header => this.header;

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
        var blockDetails = await client.Rpc.Block(this.Hash);
        if (blockDetails.Block is null) throw new BlockHashNotFoundException(this.Hash);

        return new BlockBody(client, blockDetails, cachedEvents);
    }

}

