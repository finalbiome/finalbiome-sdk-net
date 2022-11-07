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
    /// Make some on-chain remark.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - `O(1)`<br/>
    /// # </weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 1
    /// </summary>
    public class CallRemark : BaseType
    {
        public override string TypeName() => "CallRemark";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.VecU8 Remark { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Remark = new FinalBiome.Sdk.VecU8();
            Remark.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
