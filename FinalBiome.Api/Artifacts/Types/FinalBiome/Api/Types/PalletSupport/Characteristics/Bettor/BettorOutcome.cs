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
namespace FinalBiome.Api.Types.PalletSupport.Characteristics.Bettor
{
    /// <summary>
    /// Generated from meta with Type Id 160
    /// </summary>
    public class BettorOutcome : Codec
    {
        public override string TypeName() => "BettorOutcome";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.BoundedVecU8 Name { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Probability { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Characteristics.Bettor.OutcomeResult Result { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Name.Encode());
            bytes.AddRange(Probability.Encode());
            bytes.AddRange(Result.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Name = new FinalBiome.Api.Types.BoundedVecU8();
            Name.Decode(byteArray, ref p);

            Probability = new FinalBiome.Api.Types.Primitive.U32();
            Probability.Decode(byteArray, ref p);

            Result = new FinalBiome.Api.Types.PalletSupport.Characteristics.Bettor.OutcomeResult();
            Result.Decode(byteArray, ref p);

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
