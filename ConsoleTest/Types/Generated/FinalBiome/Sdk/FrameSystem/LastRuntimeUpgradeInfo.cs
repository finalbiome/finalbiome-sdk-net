///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem
{
    /// <summary>
    /// Generated from meta with Type Id 64
    /// </summary>
    public class LastRuntimeUpgradeInfo : BaseComposite
    {
        public override string TypeName() => "LastRuntimeUpgradeInfo";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.CompactU32 SpecVersion { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.Str SpecName { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(SpecVersion.Encode());
            bytes.AddRange(SpecName.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            SpecVersion = new FinalBiome.Sdk.CompactU32();
            SpecVersion.Decode(byteArray, ref p);

            SpecName = new Ajuna.NetApi.Model.Types.Primitive.Str();
            SpecName.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
