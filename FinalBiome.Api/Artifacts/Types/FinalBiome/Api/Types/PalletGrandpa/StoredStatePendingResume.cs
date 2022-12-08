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
    /// Generated from meta with Type Id 102, Variant Id 3
    /// </summary>
    public class StoredStatePendingResume : Codec
    {
        public override string TypeName() => "StoredStatePendingResume";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U32 ScheduledAt { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Delay { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ScheduledAt = new FinalBiome.Api.Types.Primitive.U32();
            ScheduledAt.Decode(byteArray, ref p);

            Delay = new FinalBiome.Api.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
