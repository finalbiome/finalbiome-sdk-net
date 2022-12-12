///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletSudo.Pallet
{
    /// <summary>
    /// The \[sudoer\] just switched identity; the old key is supplied if one existed.<br/>
    ///
    ///
    /// Generated from meta with Type Id 35, Variant Id 1
    /// </summary>
    public class EventKeyChanged : Codec
    {
        public override string TypeName() => "EventKeyChanged";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.OptionAccountId32 OldSudoer { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            OldSudoer = new FinalBiome.Api.Types.OptionAccountId32();
            OldSudoer.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
