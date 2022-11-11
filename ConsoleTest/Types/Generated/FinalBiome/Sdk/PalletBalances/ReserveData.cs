///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances
{
    /// <summary>
    /// Generated from meta with Type Id 117
    /// </summary>
    public class ReserveData : BaseComposite
    {
        public override string TypeName() => "ReserveData";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.Model.Types.Base.Array8U8 Id { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U128 Amount { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Id.Encode());
            bytes.AddRange(Amount.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Id = new FinalBiome.Sdk.Model.Types.Base.Array8U8();
            Id.Decode(byteArray, ref p);

            Amount = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
