
namespace FinalBiome.Api.Events;

using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public class Events
{
    Hash blockHash;
    FinalBiome.Api.Types.FrameSystem.VecEventRecord eventRecords;
    public Events(
        Hash blockHash,
        FinalBiome.Api.Types.FrameSystem.VecEventRecord eventRecords
    )
    {
        this.blockHash = blockHash;
        this.eventRecords = eventRecords;
    }

    /// <summary>
    /// The number of events
    /// </summary>
    public int Length => this.eventRecords.Value.Length;

    /// <summary>
    /// Are there no events in this block?
    /// </summary>
    public bool isEmpty => this.Length == 0;

    /// <summary>
    /// Return the block hash that these events are from.
    /// </summary>
    public Hash BlockHash => this.blockHash;

    /// <summary>
    /// Return all of the events
    /// </summary>
    public FinalBiome.Api.Types.FrameSystem.VecEventRecord EventRecords => this.eventRecords;
}

