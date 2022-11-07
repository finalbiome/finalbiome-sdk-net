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
    /// Set some items of storage.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 5
    /// </summary>
    public class CallSetStorage : BaseType
    {
        public override string TypeName() => "CallSetStorage";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.Model.Types.Base.VecTuple_VecU8_VecU8 Items { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Items = new FinalBiome.Sdk.Model.Types.Base.VecTuple_VecU8_VecU8();
            Items.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
