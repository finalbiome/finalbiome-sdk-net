///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletTimestamp.Pallet
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
    /// # <weight><br/>
    /// - `O(1)` (Note that implementations of `OnTimestampSet` must also be `O(1)`)<br/>
    /// - 1 storage read and 1 storage mutation (codec `O(1)`). (because of `DidUpdate::take` in<br/>
    ///   `on_finalize`)<br/>
    /// - 1 event handler `on_timestamp_set`. Must be `O(1)`.<br/>
    /// # </weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 88, Variant Id 0
    /// </summary>
    public class CallSet : BaseType
    {
        public override string TypeName() => "CallSet";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.CompactU64 Now { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Now = new FinalBiome.Sdk.CompactU64();
            Now.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
