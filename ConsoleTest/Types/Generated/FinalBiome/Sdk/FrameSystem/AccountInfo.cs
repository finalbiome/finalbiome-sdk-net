///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem
{
    /// <summary>
    /// Generated from meta with Type Id 3
    /// </summary>
    public class AccountInfo : BaseType
    {
        public override string TypeName() => "AccountInfo";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U32 Nonce { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Consumers { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Providers { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Sufficients { get; private set; }
        public FinalBiome.Sdk.PalletBalances.AccountData Data { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Nonce = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Nonce.Decode(byteArray, ref p);

            Consumers = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Consumers.Decode(byteArray, ref p);

            Providers = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Providers.Decode(byteArray, ref p);

            Sufficients = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Sufficients.Decode(byteArray, ref p);

            Data = new FinalBiome.Sdk.PalletBalances.AccountData();
            Data.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
