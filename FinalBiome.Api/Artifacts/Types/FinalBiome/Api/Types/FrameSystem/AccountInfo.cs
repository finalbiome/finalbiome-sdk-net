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
    /// Generated from meta with Type Id 3
    /// </summary>
    public class AccountInfo : Codec
    {
        public override string TypeName() => "AccountInfo";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U32 Nonce { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Consumers { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Providers { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Sufficients { get; private set; }
        public FinalBiome.Api.Types.PalletBalances.AccountData Data { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Nonce.Encode());
            bytes.AddRange(Consumers.Encode());
            bytes.AddRange(Providers.Encode());
            bytes.AddRange(Sufficients.Encode());
            bytes.AddRange(Data.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Nonce = new FinalBiome.Api.Types.Primitive.U32();
            Nonce.Decode(byteArray, ref p);

            Consumers = new FinalBiome.Api.Types.Primitive.U32();
            Consumers.Decode(byteArray, ref p);

            Providers = new FinalBiome.Api.Types.Primitive.U32();
            Providers.Decode(byteArray, ref p);

            Sufficients = new FinalBiome.Api.Types.Primitive.U32();
            Sufficients.Decode(byteArray, ref p);

            Data = new FinalBiome.Api.Types.PalletBalances.AccountData();
            Data.Decode(byteArray, ref p);

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
