///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletBalances.Pallet
{
    /// <summary>
    /// A balance was set by root.<br/>
    ///
    ///
    /// Generated from meta with Type Id 32, Variant Id 3
    /// </summary>
    public class EventBalanceSet : Codec
    {
        public override string TypeName() => "EventBalanceSet";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Who { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 Free { get; private set; }
        public FinalBiome.Api.Types.Primitive.U128 Reserved { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Who = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Who.Decode(byteArray, ref p);

            Free = new FinalBiome.Api.Types.Primitive.U128();
            Free.Decode(byteArray, ref p);

            Reserved = new FinalBiome.Api.Types.Primitive.U128();
            Reserved.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
