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
    /// Generated from meta with Type Id 78
    /// </summary>
    public class PerDispatchClass : BaseComposite
    {
        public override string TypeName() => "PerDispatchClass";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U32 Normal { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Operational { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Mandatory { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Normal.Encode());
            bytes.AddRange(Operational.Encode());
            bytes.AddRange(Mandatory.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Normal = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Normal.Decode(byteArray, ref p);

            Operational = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Operational.Decode(byteArray, ref p);

            Mandatory = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Mandatory.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
