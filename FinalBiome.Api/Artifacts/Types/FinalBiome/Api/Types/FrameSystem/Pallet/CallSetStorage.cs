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
    /// Set some items of storage.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 5
    /// </summary>
    public class CallSetStorage : Codec
    {
        public override string TypeName() => "CallSetStorage";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.VecTuple_VecU8_VecU8 Items { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Items = new FinalBiome.Api.Types.VecTuple_VecU8_VecU8();
            Items.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}