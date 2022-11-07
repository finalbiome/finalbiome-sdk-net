///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances.Pallet
{
    /// <summary>
    /// Exactly as `transfer`, except the origin must be root and the source account may be<br/>
    /// specified.<br/>
    /// # <weight><br/>
    /// - Same as transfer, but additional read and write because the source account is not<br/>
    ///   assumed to be in the overlay.<br/>
    /// # </weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 120, Variant Id 2
    /// </summary>
    public class CallForceTransfer : BaseType
    {
        public override string TypeName() => "CallForceTransfer";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress Source { get; private set; }
        public FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress Dest { get; private set; }
        public FinalBiome.Sdk.CompactU128 Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Source = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
            Source.Decode(byteArray, ref p);

            Dest = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
            Dest.Decode(byteArray, ref p);

            Value = new FinalBiome.Sdk.CompactU128();
            Value.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
