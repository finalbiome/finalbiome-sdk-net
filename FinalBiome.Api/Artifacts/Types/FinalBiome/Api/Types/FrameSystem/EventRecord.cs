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
namespace FinalBiome.Api.Types.FrameSystem
{
    /// <summary>
    /// Generated from meta with Type Id 16
    /// </summary>
    public class EventRecord : Codec
    {
        public override string TypeName() => "EventRecord";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.FrameSystem.Phase Phase { get; private set; }
        public FinalBiome.Api.Types.FinalbiomeNodeRuntime.Event Event { get; private set; }
        public FinalBiome.Api.Types.PrimitiveTypes.VecH256 Topics { get; private set; }
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

            Phase = new FinalBiome.Api.Types.FrameSystem.Phase();
            Phase.Decode(byteArray, ref p);

            Event = new FinalBiome.Api.Types.FinalbiomeNodeRuntime.Event();
            Event.Decode(byteArray, ref p);

            Topics = new FinalBiome.Api.Types.PrimitiveTypes.VecH256();
            Topics.Decode(byteArray, ref p);

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
