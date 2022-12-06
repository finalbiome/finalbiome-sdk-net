///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.FrameSystem.Limits
{
    /// <summary>
    /// Generated from meta with Type Id 75
    /// </summary>
    public class WeightsPerClass : Codec
    {
        public override string TypeName() => "WeightsPerClass";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U64 BaseExtrinsic { get; private set; }
        public FinalBiome.Api.Types.OptionU64 MaxExtrinsic { get; private set; }
        public FinalBiome.Api.Types.OptionU64 MaxTotal { get; private set; }
        public FinalBiome.Api.Types.OptionU64 Reserved { get; private set; }
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

            BaseExtrinsic = new FinalBiome.Api.Types.Primitive.U64();
            BaseExtrinsic.Decode(byteArray, ref p);

            MaxExtrinsic = new FinalBiome.Api.Types.OptionU64();
            MaxExtrinsic.Decode(byteArray, ref p);

            MaxTotal = new FinalBiome.Api.Types.OptionU64();
            MaxTotal.Decode(byteArray, ref p);

            Reserved = new FinalBiome.Api.Types.OptionU64();
            Reserved.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
