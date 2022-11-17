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
    /// Generated from meta with Type Id 164
    /// </summary>
    public class MechanicUpgradeData : Codec
    {
        public override string TypeName() => "MechanicUpgradeData";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.MechanicId MechanicId { get; private set; }
        public FinalBiome.Api.Types.PalletMechanics.Types.MechanicUpgradePayload Payload { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(MechanicId.Encode());
            bytes.AddRange(Payload.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            MechanicId = new FinalBiome.Api.Types.PalletSupport.MechanicId();
            MechanicId.Decode(byteArray, ref p);

            Payload = new FinalBiome.Api.Types.PalletMechanics.Types.MechanicUpgradePayload();
            Payload.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
