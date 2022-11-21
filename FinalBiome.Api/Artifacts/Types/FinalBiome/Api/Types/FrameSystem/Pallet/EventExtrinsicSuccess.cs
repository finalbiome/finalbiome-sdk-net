///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.FrameSystem.Pallet
{
    /// <summary>
    /// An extrinsic completed successfully.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18, Variant Id 0
    /// </summary>
    public class EventExtrinsicSuccess : Codec
    {
        public override string TypeName() => "EventExtrinsicSuccess";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.FrameSupport.Weights.DispatchInfo DispatchInfo { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            DispatchInfo = new FinalBiome.Api.Types.FrameSupport.Weights.DispatchInfo();
            DispatchInfo.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}