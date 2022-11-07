///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Pallet
{
    /// <summary>
    /// On on-chain remark happened.<br/>
    ///
    ///
    /// Generated from meta with Type Id 18, Variant Id 5
    /// </summary>
    public class EventRemarked : BaseType
    {
        public override string TypeName() => "EventRemarked";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpCore.Crypto.AccountId32 Sender { get; private set; }
        public FinalBiome.Sdk.PrimitiveTypes.H256 Hash { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Sender = new FinalBiome.Sdk.SpCore.Crypto.AccountId32();
            Sender.Decode(byteArray, ref p);

            Hash = new FinalBiome.Sdk.PrimitiveTypes.H256();
            Hash.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
