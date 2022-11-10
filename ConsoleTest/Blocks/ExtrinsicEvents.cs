using System;
using System.Collections;
using Ajuna.NetApi.Model.Types.Base;
using FinalBiome.Sdk.FrameSystem;

namespace FinalBiome.Sdk.Blocks
{
    /// <summary>
    /// The events associated with a given extrinsic.
    /// </summary>
    public class ExtrinsicEvents : IEnumerable<FrameSystem.EventRecord>
    {
        /// <summary>
        ///The hash of the extrinsic (handy to expose here because
        /// this type is returned from TxProgress things in the most
        /// basic flows, so it's the only place people can access it
        /// without complicating things for themselves).
        /// </summary>
        Hash extHash;
        /// <summary>
        /// The index of the extrinsic
        /// </summary>
        int idx;
        /// <summary>
        /// All of the events in the block
        /// </summary>
        Events.Events events;

        public ExtrinsicEvents(Ajuna.NetApi.Model.Types.Base.Hash extHash,
                               int idx,
                               Events.Events events)
        {
            this.extHash = extHash;
            this.idx = idx;
            this.events = events;
        }

        /// <summary>
        /// Return the hash of the block that the extrinsic is in.
        /// </summary>
        public Hash BlockHash => this.events.BlockHash;

        /// <summary>
        /// The index of the extrinsic that these events are produced from.
        /// </summary>
        public int ExtrinsicIndex => this.idx;

        /// <summary>
        /// Return the hash of the extrinsic.
        /// </summary>
        public Hash ExtrinsicHash => this.extHash;

        /// <summary>
        /// Return all of the events in the block that the extrinsic is in.
        /// </summary>
        public Events.Events AllEventsInBlock => this.events;

        /// <summary>
        /// Iterate over all of the raw events associated with this transaction.
        ///
        /// This works in the same way that [`Events.Events.iter()`] does, with the
        /// exception that it filters out events not related to the submitted extrinsic.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<EventRecord> GetEnumerator()
        {
            var records = this.events.EventRecords.Value;
            for (int i = 0; i < records.Length; i++)
            {
                if (records[i].Phase.Value == InnerPhase.ApplyExtrinsic &&
                    ((Ajuna.NetApi.Model.Types.Primitive.U32)(records[i].Phase.Value2)).Value == this.idx)
                {
                    yield return records[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

