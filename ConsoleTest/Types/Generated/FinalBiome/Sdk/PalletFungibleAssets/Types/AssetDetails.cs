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
    /// Generated from meta with Type Id 173
    /// </summary>
    public class AssetDetails : BaseComposite
    {
        public override string TypeName() => "AssetDetails";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Supply { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Accounts { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 References { get; private set; }
        public FinalBiome.Sdk.BoundedVecU8 Name { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA TopUpped { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionCupFA CupGlobal { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionCupFA CupLocal { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Owner.Encode());
            bytes.AddRange(Supply.Encode());
            bytes.AddRange(Accounts.Encode());
            bytes.AddRange(References.Encode());
            bytes.AddRange(Name.Encode());
            bytes.AddRange(TopUpped.Encode());
            bytes.AddRange(CupGlobal.Encode());
            bytes.AddRange(CupLocal.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Owner = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            Supply = new FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Supply.Decode(byteArray, ref p);

            Accounts = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Accounts.Decode(byteArray, ref p);

            References = new Ajuna.NetApi.Model.Types.Primitive.U32();
            References.Decode(byteArray, ref p);

            Name = new FinalBiome.Sdk.BoundedVecU8();
            Name.Decode(byteArray, ref p);

            TopUpped = new FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA();
            TopUpped.Decode(byteArray, ref p);

            CupGlobal = new FinalBiome.Sdk.Model.Types.Base.OptionCupFA();
            CupGlobal.Decode(byteArray, ref p);

            CupLocal = new FinalBiome.Sdk.Model.Types.Base.OptionCupFA();
            CupLocal.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
