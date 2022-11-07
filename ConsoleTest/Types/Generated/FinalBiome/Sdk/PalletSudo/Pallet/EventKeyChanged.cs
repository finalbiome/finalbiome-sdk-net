///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSudo.Pallet
{
    /// <summary>
    /// The \[sudoer\] just switched identity; the old key is supplied if one existed.<br/>
    ///
    ///
    /// Generated from meta with Type Id 35, Variant Id 1
    /// </summary>
    public class EventKeyChanged : BaseType
    {
        public override string TypeName() => "EventKeyChanged";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.Model.Types.Base.OptionAccountId32 OldSudoer { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OldSudoer = new FinalBiome.Sdk.Model.Types.Base.OptionAccountId32();
            OldSudoer.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
