///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletGrandpa.Pallet
{
    /// <summary>
    /// Note that the current authority set of the GRANDPA finality gadget has stalled.<br/>
    /// <para></para>
    /// This will trigger a forced authority set change at the beginning of the next session, to<br/>
    /// be enacted `delay` blocks after that. The `delay` should be high enough to safely assume<br/>
    /// that the block signalling the forced change will not be re-orged e.g. 1000 blocks.<br/>
    /// The block production rate (which may be slowed down because of finality lagging) should<br/>
    /// be taken into account when choosing the `delay`. The GRANDPA voters based on the new<br/>
    /// authority will start voting on top of `best_finalized_block_number` for new finalized<br/>
    /// blocks. `best_finalized_block_number` should be the highest of the latest finalized<br/>
    /// block of all validators of the new authority set.<br/>
    /// <para></para>
    /// Only callable by root.<br/>
    ///
    ///
    /// Generated from meta with Type Id 106, Variant Id 2
    /// </summary>
    public class CallNoteStalled : Codec
    {
        public override string TypeName() => "CallNoteStalled";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U32 Delay { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 BestFinalizedBlockNumber { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Delay = new FinalBiome.Api.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);

            BestFinalizedBlockNumber = new FinalBiome.Api.Types.Primitive.U32();
            BestFinalizedBlockNumber.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
