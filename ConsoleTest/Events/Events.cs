
using System.Data.SqlTypes;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
namespace FinalBiome.Sdk.Events
{
    public class Events
    {
        Hash blockHash;
        FinalBiome.Sdk.FrameSystem.VecEventRecord eventRecords;
        public Events(
            Ajuna.NetApi.Model.Types.Base.Hash blockHash,
            FinalBiome.Sdk.FrameSystem.VecEventRecord eventRecords
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
        public FinalBiome.Sdk.FrameSystem.VecEventRecord EventRecords => this.eventRecords;
    }
}

