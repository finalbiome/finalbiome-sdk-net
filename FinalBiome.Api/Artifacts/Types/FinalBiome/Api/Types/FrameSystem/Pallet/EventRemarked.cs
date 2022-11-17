///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.FrameSystem.Pallet
{
    /// <summary>
    /// On on-chain remark happened.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18, Variant Id 5
    /// </summary>
    public class EventRemarked : Codec
    {
        public override string TypeName() => "EventRemarked";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpCore.Crypto.AccountId32 Sender { get; private set; }
        public FinalBiome.Api.Types.PrimitiveTypes.H256 Hash { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Sender = new FinalBiome.Api.Types.SpCore.Crypto.AccountId32();
            Sender.Decode(byteArray, ref p);

            Hash = new FinalBiome.Api.Types.PrimitiveTypes.H256();
            Hash.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
