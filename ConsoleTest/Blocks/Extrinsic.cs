using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;

namespace FinalBiome.Sdk.Blocks
{
    /// <summary>
    /// A single extrinsic in a block.
    /// </summary>
    public class Extrinsic
    {
        private int index;
        private BaseVec<U8> extrinsic;
        private Client client;
        private Hash blockHash;
        private CachedEvents cachedEvents;

        public Extrinsic(int index, BaseVec<U8> extrinsic, Client client, Hash blockHash, CachedEvents cachedEvents)
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

        public BaseVec<U8> BlockExtrinsic => this.extrinsic;

        /// <summary>
        /// The events associated with the extrinsic.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "VSTHRD200:Use \"Async\" suffix for async methods", Justification = "<Pending>")]
        public async Task<ExtrinsicEvents> Events()
        {
            var events = await this.cachedEvents.GetEvents(client, this.blockHash);
            Hash extHash = new Hash();
            extHash.Create(Ajuna.NetApi.HashExtension.BlakeTwo256(this.extrinsic.Bytes));
            return new ExtrinsicEvents(extHash, this.index, events);
        }
    }
}