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
namespace FinalBiome.Api.Types.PalletTimestamp.Pallet
{
    /// <summary>
    /// Set the current time.<br/>
    /// <para></para>
    /// This call should be invoked exactly once per block. It will panic at the finalization<br/>
    /// phase, if this call hasn't been invoked by that time.<br/>
    /// <para></para>
    /// The timestamp should be greater than the previous one by the amount specified by<br/>
    /// `MinimumPeriod`.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be `Inherent`.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - `O(1)` (Note that implementations of `OnTimestampSet` must also be `O(1)`)<br/>
    /// - 1 storage read and 1 storage mutation (codec `O(1)`). (because of `DidUpdate::take` in<br/>
    ///   `on_finalize`)<br/>
    /// - 1 event handler `on_timestamp_set`. Must be `O(1)`.<br/>
    /// # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 96, Variant Id 0
    /// </summary>
    public class CallSet : Codec
    {
        public override string TypeName() => "CallSet";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.CompactU64 Now { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Now = new FinalBiome.Api.Types.CompactU64();
            Now.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
