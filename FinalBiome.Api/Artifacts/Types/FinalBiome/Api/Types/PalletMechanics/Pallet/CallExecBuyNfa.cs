///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletMechanics.Pallet
{
    /// <summary>
    /// Execute mechanic `Buy NFA`<br/>
    ///
    ///
    /// Generated from meta with Type Id 163, Variant Id 0
    /// </summary>
    public class CallExecBuyNfa : Codec
    {
        public override string TypeName() => "CallExecBuyNfa";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId ClassId { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 OfferId { get; private set; }
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

            OfferId = new FinalBiome.Api.Types.Primitive.U32();
            OfferId.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
