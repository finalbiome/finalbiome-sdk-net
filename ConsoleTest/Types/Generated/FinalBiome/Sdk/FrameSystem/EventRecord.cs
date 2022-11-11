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
    /// Generated from meta with Type Id 16
    /// </summary>
    public class EventRecord : BaseComposite
    {
        public override string TypeName() => "EventRecord";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.FrameSystem.Phase Phase { get; private set; }
        public FinalBiome.Sdk.FinalbiomeNodeRuntime.Event Event { get; private set; }
        public FinalBiome.Sdk.PrimitiveTypes.VecH256 Topics { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Phase.Encode());
            bytes.AddRange(Event.Encode());
            bytes.AddRange(Topics.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Phase = new FinalBiome.Sdk.FrameSystem.Phase();
            Phase.Decode(byteArray, ref p);

            Event = new FinalBiome.Sdk.FinalbiomeNodeRuntime.Event();
            Event.Decode(byteArray, ref p);

            Topics = new FinalBiome.Sdk.PrimitiveTypes.VecH256();
            Topics.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
