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
    /// A dispatch that will fill the block weight up to the given ratio.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 0
    /// </summary>
    public class CallFillBlock : Codec
    {
        public override string TypeName() => "CallFillBlock";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpArithmetic.PerThings.Perbill Ratio { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Ratio = new FinalBiome.Api.Types.SpArithmetic.PerThings.Perbill();
            Ratio.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}