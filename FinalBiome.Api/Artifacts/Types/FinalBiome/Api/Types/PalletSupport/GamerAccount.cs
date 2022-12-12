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
    /// Generated from meta with Type Id 53
    /// </summary>
    public class GamerAccount : Codec
    {
        public override string TypeName() => "GamerAccount";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 AccountId { get; private set; }
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 OrganizationId { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(AccountId.Encode());
            bytes.AddRange(OrganizationId.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            AccountId = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            AccountId.Decode(byteArray, ref p);

            OrganizationId = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            OrganizationId.Decode(byteArray, ref p);

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
