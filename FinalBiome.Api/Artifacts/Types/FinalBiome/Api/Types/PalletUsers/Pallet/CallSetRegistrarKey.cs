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
namespace FinalBiome.Api.Types.PalletUsers.Pallet
{
    /// <summary>
    /// Authenticates the current registrar key and sets the given AccountId (`new`) as the new<br/>
    /// registrar key.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - One DB read.<br/>
    /// - One DB change.<br/>
    /// # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 139, Variant Id 0
    /// </summary>
    public class CallSetRegistrarKey : Codec
    {
        public override string TypeName() => "CallSetRegistrarKey";

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
