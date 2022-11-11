///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Limits
{
    /// <summary>
    /// Generated from meta with Type Id 75
    /// </summary>
    public class WeightsPerClass : BaseComposite
    {
        public override string TypeName() => "WeightsPerClass";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U64 BaseExtrinsic { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionU64 MaxExtrinsic { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionU64 MaxTotal { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionU64 Reserved { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(BaseExtrinsic.Encode());
            bytes.AddRange(MaxExtrinsic.Encode());
            bytes.AddRange(MaxTotal.Encode());
            bytes.AddRange(Reserved.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            BaseExtrinsic = new Ajuna.NetApi.Model.Types.Primitive.U64();
            BaseExtrinsic.Decode(byteArray, ref p);

            MaxExtrinsic = new FinalBiome.Sdk.Model.Types.Base.OptionU64();
            MaxExtrinsic.Decode(byteArray, ref p);

            MaxTotal = new FinalBiome.Sdk.Model.Types.Base.OptionU64();
            MaxTotal.Decode(byteArray, ref p);

            Reserved = new FinalBiome.Sdk.Model.Types.Base.OptionU64();
            Reserved.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
