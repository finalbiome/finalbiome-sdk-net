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
    /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo<br/>
    /// key.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB change.<br/>
    /// # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 136, Variant Id 2
    /// </summary>
    public class CallSetKey : Codec
    {
        public override string TypeName() => "CallSetKey";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress _New { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            _New = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            _New.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
