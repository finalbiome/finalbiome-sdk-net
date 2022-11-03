///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Types
{
    /// <summary>
    /// Generated from meta with Type Id 192
    /// </summary>
    public class MechanicDetails : BaseType
    {
        public override string TypeName() => "MechanicDetails";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Owner { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 TimeoutId { get; private set; }
        public FinalBiome.Sdk.PalletSupport.BoundedVecLockedAccet Locked { get; private set; }
        public FinalBiome.Sdk.PalletMechanics.Types.MechanicData Data { get; private set; }
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

            TimeoutId = new Ajuna.NetApi.Model.Types.Primitive.U32();
            TimeoutId.Decode(byteArray, ref p);

            Locked = new FinalBiome.Sdk.PalletSupport.BoundedVecLockedAccet();
            Locked.Decode(byteArray, ref p);

            Data = new FinalBiome.Sdk.PalletMechanics.Types.MechanicData();
            Data.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
