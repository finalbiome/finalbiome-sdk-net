///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport.Characteristics.Bettor
{
    /// <summary>
    /// Generated from meta with Type Id 149
    /// </summary>
    public class Bettor : BaseComposite
    {
        public override string TypeName() => "Bettor";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.BoundedVecBettorOutcome Outcomes { get; private set; }
        public FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.BoundedVecBettorWinning Winnings { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Rounds { get; private set; }
        public FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.DrawOutcomeResult DrawOutcome { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Outcomes.Encode());
            bytes.AddRange(Winnings.Encode());
            bytes.AddRange(Rounds.Encode());
            bytes.AddRange(DrawOutcome.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Outcomes = new FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.BoundedVecBettorOutcome();
            Outcomes.Decode(byteArray, ref p);

            Winnings = new FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.BoundedVecBettorWinning();
            Winnings.Decode(byteArray, ref p);

            Rounds = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Rounds.Decode(byteArray, ref p);

            DrawOutcome = new FinalBiome.Sdk.PalletSupport.Characteristics.Bettor.DrawOutcomeResult();
            DrawOutcome.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
