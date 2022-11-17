///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletMechanics.Types
{
    /// <summary>
    /// Generated from meta with Type Id 192
    /// </summary>
    public class MechanicDetails : Codec
    {
        public override string TypeName() => "MechanicDetails";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 TimeoutId { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.BoundedVecLockedAccet Locked { get; private set; }
        public FinalBiome.Api.Types.PalletMechanics.Types.MechanicData Data { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Owner.Encode());
            bytes.AddRange(TimeoutId.Encode());
            bytes.AddRange(Locked.Encode());
            bytes.AddRange(Data.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Owner = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            TimeoutId = new FinalBiome.Api.Types.Primitive.U32();
            TimeoutId.Decode(byteArray, ref p);

            Locked = new FinalBiome.Api.Types.PalletSupport.BoundedVecLockedAccet();
            Locked.Decode(byteArray, ref p);

            Data = new FinalBiome.Api.Types.PalletMechanics.Types.MechanicData();
            Data.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
