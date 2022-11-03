///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport.TypesNfa
{
    /// <summary>
    /// Generated from meta with Type Id 185
    /// </summary>
    public class AssetDetails : BaseType
    {
        public override string TypeName() => "AssetDetails";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Sdk.PalletSupport.Locker Locked { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Owner = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            Locked = new FinalBiome.Sdk.PalletSupport.Locker();
            Locked.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
