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
    /// Make some on-chain remark.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - `O(1)`<br/>
    /// # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 1
    /// </summary>
    public class CallRemark : Codec
    {
        public override string TypeName() => "CallRemark";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.VecU8 Remark { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Remark = new FinalBiome.Api.Types.VecU8();
            Remark.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}