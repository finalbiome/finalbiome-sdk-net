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
    /// Attribute metadata has been removed for the asset class.<br/>
    ///
    ///
    /// Generated from meta with Type Id 44, Variant Id 5
    /// </summary>
    public class EventAttributeRemoved : BaseType
    {
        public override string TypeName() => "EventAttributeRemoved";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId ClassId { get; private set; }
        public FinalBiome.Sdk.BoundedVecU8 Key { get; private set; }
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

            _size = p - start;
        }
    }
}
