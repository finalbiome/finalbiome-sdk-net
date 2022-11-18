
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Blocks;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

/// <summary>
/// A single extrinsic in a block.
/// </summary>
public class Extrinsic
{
    private int index;
    private Vec<U8> extrinsic;
    private Client client;
    private Hash blockHash;
    private CachedEvents cachedEvents;

    public Extrinsic(int index, Vec<U8> extrinsic, Client client, Hash blockHash, CachedEvents cachedEvents)
    {
        this.index = index;
        this.extrinsic = extrinsic;
        this.client = client;
        this.blockHash = blockHash;
        this.cachedEvents = cachedEvents;
    }

    /// <summary>
    /// The index of the extrinsic in the block.
    /// </summary>
    public int Index => this.index;

    public Vec<U8> BlockExtrinsic => this.extrinsic;

    /// <summary>
    /// The events associated with the extrinsic.
    /// </summary>
    public async Task<ExtrinsicEvents> Events()
    {
        var events = await this.cachedEvents.GetEvents(client, this.blockHash);
        Hash extHash = new Hash();
        extHash.Init(Hasher.BlakeTwo256(this.extrinsic.Bytes));
        return new ExtrinsicEvents(extHash, this.index, events);
    }
}