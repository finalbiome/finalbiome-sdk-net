///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Pallet
{
    /// <summary>
    /// Mechanics done.<br/>
    ///
    ///
    /// Generated from meta with Type Id 52, Variant Id 0
    /// </summary>
    public class EventFinished : BaseType
    {
        public override string TypeName() => "EventFinished";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Id { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionEventMechanicResultData Result { get; private set; }
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

            Id = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Id.Decode(byteArray, ref p);

            Result = new FinalBiome.Sdk.Model.Types.Base.OptionEventMechanicResultData();
            Result.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
