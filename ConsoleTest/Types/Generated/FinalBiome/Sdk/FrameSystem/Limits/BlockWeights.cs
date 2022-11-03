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
    /// Generated from meta with Type Id 73
    /// </summary>
    public class BlockWeights : BaseType
    {
        public override string TypeName() => "BlockWeights";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U64 BaseBlock { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U64 MaxBlock { get; private set; }
        public FinalBiome.Sdk.FrameSupport.Weights.PerDispatchClass PerClass { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            BaseBlock = new Ajuna.NetApi.Model.Types.Primitive.U64();
            BaseBlock.Decode(byteArray, ref p);

            MaxBlock = new Ajuna.NetApi.Model.Types.Primitive.U64();
            MaxBlock.Decode(byteArray, ref p);

            PerClass = new FinalBiome.Sdk.FrameSupport.Weights.PerDispatchClass();
            PerClass.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
