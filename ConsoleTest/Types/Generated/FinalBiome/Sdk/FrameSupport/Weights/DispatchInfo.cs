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
    /// Generated from meta with Type Id 19
    /// </summary>
    public class DispatchInfo : BaseComposite
    {
        public override string TypeName() => "DispatchInfo";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U64 Weight { get; private set; }
        public FinalBiome.Sdk.FrameSupport.Weights.DispatchClass Class { get; private set; }
        public FinalBiome.Sdk.FrameSupport.Weights.Pays PaysFee { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Weight.Encode());
            bytes.AddRange(Class.Encode());
            bytes.AddRange(PaysFee.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Weight = new Ajuna.NetApi.Model.Types.Primitive.U64();
            Weight.Decode(byteArray, ref p);

            Class = new FinalBiome.Sdk.FrameSupport.Weights.DispatchClass();
            Class.Decode(byteArray, ref p);

            PaysFee = new FinalBiome.Sdk.FrameSupport.Weights.Pays();
            PaysFee.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
