///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletGrandpa.Pallet
{
    /// <summary>
    /// New authority set has been applied.<br/>
    ///
    ///
    /// Generated from meta with Type Id 27, Variant Id 0
    /// </summary>
    public class EventNewAuthorities : BaseType
    {
        public override string TypeName() => "EventNewAuthorities";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.Model.Types.Base.VecTuple_Public_U64 AuthoritySet { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            AuthoritySet = new FinalBiome.Sdk.Model.Types.Base.VecTuple_Public_U64();
            AuthoritySet.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
