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
namespace FinalBiome.Api.Types.PalletSupport
{
    /// <summary>
    /// Generated from meta with Type Id 174
    /// </summary>
    public class MechanicId : Codec
    {
        public override string TypeName() => "MechanicId";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.GamerAccount GamerAccount { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Nonce { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(GamerAccount.Encode());
            bytes.AddRange(Nonce.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            GamerAccount = new FinalBiome.Api.Types.PalletSupport.GamerAccount();
            GamerAccount.Decode(byteArray, ref p);

            Nonce = new FinalBiome.Api.Types.Primitive.U32();
            Nonce.Decode(byteArray, ref p);

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
