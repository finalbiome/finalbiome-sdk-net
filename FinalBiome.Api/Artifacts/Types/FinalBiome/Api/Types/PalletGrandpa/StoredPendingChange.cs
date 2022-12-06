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
namespace FinalBiome.Api.Types.PalletGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 96
    /// </summary>
    public class StoredPendingChange : Codec
    {
        public override string TypeName() => "StoredPendingChange";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U32 ScheduledAt { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Delay { get; private set; }
        public FinalBiome.Api.Types.WeakBoundedVecTuple_Public_U64 NextAuthorities { get; private set; }
        public FinalBiome.Api.Types.OptionU32 Forced { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(ScheduledAt.Encode());
            bytes.AddRange(Delay.Encode());
            bytes.AddRange(NextAuthorities.Encode());
            bytes.AddRange(Forced.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ScheduledAt = new FinalBiome.Api.Types.Primitive.U32();
            ScheduledAt.Decode(byteArray, ref p);

            Delay = new FinalBiome.Api.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);

            NextAuthorities = new FinalBiome.Api.Types.WeakBoundedVecTuple_Public_U64();
            NextAuthorities.Decode(byteArray, ref p);

            Forced = new FinalBiome.Api.Types.OptionU32();
            Forced.Decode(byteArray, ref p);

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
