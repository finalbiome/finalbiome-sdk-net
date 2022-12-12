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
namespace FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    /// New attribute metadata has been set for the asset class.<br/>
    ///
    ///
    /// Generated from meta with Type Id 44, Variant Id 4
    /// </summary>
    public class EventAttributeCreated : Codec
    {
        public override string TypeName() => "EventAttributeCreated";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId ClassId { get; private set; }
        public FinalBiome.Api.Types.BoundedVecU8 Key { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.AttributeValue Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ClassId = new FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId();
            ClassId.Decode(byteArray, ref p);

            Key = new FinalBiome.Api.Types.BoundedVecU8();
            Key.Decode(byteArray, ref p);

            Value = new FinalBiome.Api.Types.PalletSupport.AttributeValue();
            Value.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
