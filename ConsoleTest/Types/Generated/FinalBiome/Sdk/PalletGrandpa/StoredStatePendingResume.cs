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
    /// Generated from meta with Type Id 95, Variant Id 3
    /// </summary>
    public class StoredStatePendingResume : BaseType
    {
        public override string TypeName() => "StoredStatePendingResume";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U32 ScheduledAt { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Delay { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ScheduledAt = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ScheduledAt.Decode(byteArray, ref p);

            Delay = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Delay.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
