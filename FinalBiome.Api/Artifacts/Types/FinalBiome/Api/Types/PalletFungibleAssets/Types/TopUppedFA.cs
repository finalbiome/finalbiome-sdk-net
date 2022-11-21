///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletFungibleAssets.Types
{
    /// <summary>
    /// Generated from meta with Type Id 141
    /// </summary>
    public class TopUppedFA : Codec
    {
        public override string TypeName() => "TopUppedFA";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Speed { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Speed.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Speed = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Speed.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}