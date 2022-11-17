///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletSupport
{
    /// <summary>
    /// Generated from meta with Type Id 165
    /// </summary>
    public class MechanicId : Codec
    {
        public override string TypeName() => "MechanicId";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 AccountId { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Nonce { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(AccountId.Encode());
            bytes.AddRange(Nonce.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            AccountId = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            AccountId.Decode(byteArray, ref p);

            Nonce = new FinalBiome.Api.Types.Primitive.U32();
            Nonce.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
