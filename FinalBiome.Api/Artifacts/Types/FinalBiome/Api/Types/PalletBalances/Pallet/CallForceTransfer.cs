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
    /// Exactly as `transfer`, except the origin must be root and the source account may be<br/>
    /// specified.<br/>
    /// # &lt;weight&gt;<br/>
    /// - Same as transfer, but additional read and write because the source account is not<br/>
    ///   assumed to be in the overlay.<br/>
    /// # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 120, Variant Id 2
    /// </summary>
    public class CallForceTransfer : Codec
    {
        public override string TypeName() => "CallForceTransfer";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress Source { get; private set; }
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress Dest { get; private set; }
        public FinalBiome.Api.Types.CompactU128 Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Source = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            Source.Decode(byteArray, ref p);

            Dest = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            Dest.Decode(byteArray, ref p);

            Value = new FinalBiome.Api.Types.CompactU128();
            Value.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
