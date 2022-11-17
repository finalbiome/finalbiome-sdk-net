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
    /// Set the number of pages in the WebAssembly environment's heap.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 2
    /// </summary>
    public class CallSetHeapPages : Codec
    {
        public override string TypeName() => "CallSetHeapPages";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U64 Pages { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Pages = new FinalBiome.Api.Types.Primitive.U64();
            Pages.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
