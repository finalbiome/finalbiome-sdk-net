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
namespace FinalBiome.Api.Types.PalletFungibleAssets.Types
{
    /// <summary>
    /// Generated from meta with Type Id 173
    /// </summary>
    public class AssetDetails : Codec
    {
        public override string TypeName() => "AssetDetails";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance Supply { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Accounts { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 References { get; private set; }
        public FinalBiome.Api.Types.BoundedVecU8 Name { get; private set; }
        public FinalBiome.Api.Types.OptionTopUppedFA TopUpped { get; private set; }
        public FinalBiome.Api.Types.OptionCupFA CupGlobal { get; private set; }
        public FinalBiome.Api.Types.OptionCupFA CupLocal { get; private set; }
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

            Owner = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            Supply = new FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance();
            Supply.Decode(byteArray, ref p);

            Accounts = new FinalBiome.Api.Types.Primitive.U32();
            Accounts.Decode(byteArray, ref p);

            References = new FinalBiome.Api.Types.Primitive.U32();
            References.Decode(byteArray, ref p);

            Name = new FinalBiome.Api.Types.BoundedVecU8();
            Name.Decode(byteArray, ref p);

            TopUpped = new FinalBiome.Api.Types.OptionTopUppedFA();
            TopUpped.Decode(byteArray, ref p);

            CupGlobal = new FinalBiome.Api.Types.OptionCupFA();
            CupGlobal.Decode(byteArray, ref p);

            CupLocal = new FinalBiome.Api.Types.OptionCupFA();
            CupLocal.Decode(byteArray, ref p);

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
