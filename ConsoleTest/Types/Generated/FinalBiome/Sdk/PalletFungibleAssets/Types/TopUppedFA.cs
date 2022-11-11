///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletFungibleAssets.Types
{
    /// <summary>
    /// Generated from meta with Type Id 141
    /// </summary>
    public class TopUppedFA : BaseComposite
    {
        public override string TypeName() => "TopUppedFA";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Speed { get; private set; }
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

            Speed = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Speed.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
