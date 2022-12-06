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
namespace FinalBiome.Api.Types.PalletBalances
{
    /// <summary>
    /// Generated from meta with Type Id 5
    /// </summary>
    public class AccountData : Codec
    {
        public override string TypeName() => "AccountData";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U128 Free { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 Reserved { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 MiscFrozen { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 FeeFrozen { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Free.Encode());
            bytes.AddRange(Reserved.Encode());
            bytes.AddRange(MiscFrozen.Encode());
            bytes.AddRange(FeeFrozen.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Free = new FinalBiome.Api.Types.Primitive.U128();
            Free.Decode(byteArray, ref p);

            Reserved = new FinalBiome.Api.Types.Primitive.U128();
            Reserved.Decode(byteArray, ref p);

            MiscFrozen = new FinalBiome.Api.Types.Primitive.U128();
            MiscFrozen.Decode(byteArray, ref p);

            FeeFrozen = new FinalBiome.Api.Types.Primitive.U128();
            FeeFrozen.Decode(byteArray, ref p);

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
