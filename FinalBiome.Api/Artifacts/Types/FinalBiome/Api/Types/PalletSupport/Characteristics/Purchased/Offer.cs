///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletSupport.Characteristics.Purchased
{
    /// <summary>
    /// Generated from meta with Type Id 161
    /// </summary>
    public class Offer : Codec
    {
        public override string TypeName() => "Offer";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId Fa { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Price { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.BoundedVecAttribute Attributes { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Fa.Encode());
            bytes.AddRange(Price.Encode());
            bytes.AddRange(Attributes.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Fa = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId();
            Fa.Decode(byteArray, ref p);

            Price = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Price.Decode(byteArray, ref p);

            Attributes = new FinalBiome.Api.Types.PalletSupport.BoundedVecAttribute();
            Attributes.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
