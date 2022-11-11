///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 96
    /// </summary>
    public class StoredPendingChange : BaseComposite
    {
        public override string TypeName() => "StoredPendingChange";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U32 ScheduledAt { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Delay { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.WeakBoundedVecTuple_Public_U64 NextAuthorities { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionU32 Forced { get; private set; }
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

            ScheduledAt = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ScheduledAt.Decode(byteArray, ref p);

            Delay = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);

            NextAuthorities = new FinalBiome.Sdk.Model.Types.Base.WeakBoundedVecTuple_Public_U64();
            NextAuthorities.Decode(byteArray, ref p);

            Forced = new FinalBiome.Sdk.Model.Types.Base.OptionU32();
            Forced.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
