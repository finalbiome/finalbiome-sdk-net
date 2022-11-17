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
    /// Mechanics done.<br/>
    ///
    ///
    /// Generated from meta with Type Id 52, Variant Id 0
    /// </summary>
    public class EventFinished : Codec
    {
        public override string TypeName() => "EventFinished";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Id { get; private set; }
        public FinalBiome.Api.Types.OptionEventMechanicResultData Result { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Owner = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Owner.Decode(byteArray, ref p);

            Id = new FinalBiome.Api.Types.Primitive.U32();
            Id.Decode(byteArray, ref p);

            Result = new FinalBiome.Api.Types.OptionEventMechanicResultData();
            Result.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
