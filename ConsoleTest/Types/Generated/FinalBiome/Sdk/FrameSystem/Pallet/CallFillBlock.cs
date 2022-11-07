///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Pallet
{
    /// <summary>
    /// A dispatch that will fill the block weight up to the given ratio.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 0
    /// </summary>
    public class CallFillBlock : BaseType
    {
        public override string TypeName() => "CallFillBlock";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpArithmetic.PerThings.Perbill Ratio { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Ratio = new FinalBiome.Sdk.SpArithmetic.PerThings.Perbill();
            Ratio.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
