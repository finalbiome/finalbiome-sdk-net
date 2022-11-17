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
    /// Kill some items from storage.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 6
    /// </summary>
    public class CallKillStorage : Codec
    {
        public override string TypeName() => "CallKillStorage";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.VecVecU8 Keys { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Keys = new FinalBiome.Api.Types.VecVecU8();
            Keys.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
