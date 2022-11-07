///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    /// New attribute metadata has been set for the asset class.<br/>
    ///
    ///
    /// Generated from meta with Type Id 44, Variant Id 4
    /// </summary>
    public class EventAttributeCreated : BaseType
    {
        public override string TypeName() => "EventAttributeCreated";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId ClassId { get; private set; }
        public FinalBiome.Sdk.BoundedVecU8 Key { get; private set; }
        public FinalBiome.Sdk.PalletSupport.AttributeValue Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            ClassId = new FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId();
            ClassId.Decode(byteArray, ref p);

            Key = new FinalBiome.Sdk.BoundedVecU8();
            Key.Decode(byteArray, ref p);

            Value = new FinalBiome.Sdk.PalletSupport.AttributeValue();
            Value.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}