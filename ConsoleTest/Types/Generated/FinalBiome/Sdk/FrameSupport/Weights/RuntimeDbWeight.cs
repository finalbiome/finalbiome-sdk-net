///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSupport.Weights
{
    /// <summary>
    /// Generated from meta with Type Id 79
    /// </summary>
    public class RuntimeDbWeight : BaseType
    {
        public override string TypeName() => "RuntimeDbWeight";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U64 Read { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U64 Write { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Read = new Ajuna.NetApi.Model.Types.Primitive.U64();
            Read.Decode(byteArray, ref p);

            Write = new Ajuna.NetApi.Model.Types.Primitive.U64();
            Write.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
