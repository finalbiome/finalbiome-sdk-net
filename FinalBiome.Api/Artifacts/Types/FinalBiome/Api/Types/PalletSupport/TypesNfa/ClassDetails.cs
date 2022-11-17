///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletSupport.TypesNfa
{
    /// <summary>
    /// Generated from meta with Type Id 181
    /// </summary>
    public class ClassDetails : Codec
    {
        public override string TypeName() => "ClassDetails";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Instances { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Attributes { get; private set; }
        public FinalBiome.Api.Types.BoundedVecU8 Name { get; private set; }
        public FinalBiome.Api.Types.OptionBettor Bettor { get; private set; }
        public FinalBiome.Api.Types.OptionPurchased Purchased { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Owner.Encode());
            bytes.AddRange(Instances.Encode());
            bytes.AddRange(Attributes.Encode());
            bytes.AddRange(Name.Encode());
            bytes.AddRange(Bettor.Encode());
            bytes.AddRange(Purchased.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Owner = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            Instances = new FinalBiome.Api.Types.Primitive.U32();
            Instances.Decode(byteArray, ref p);

            Attributes = new FinalBiome.Api.Types.Primitive.U32();
            Attributes.Decode(byteArray, ref p);

            Name = new FinalBiome.Api.Types.BoundedVecU8();
            Name.Decode(byteArray, ref p);

            Bettor = new FinalBiome.Api.Types.OptionBettor();
            Bettor.Decode(byteArray, ref p);

            Purchased = new FinalBiome.Api.Types.OptionPurchased();
            Purchased.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
