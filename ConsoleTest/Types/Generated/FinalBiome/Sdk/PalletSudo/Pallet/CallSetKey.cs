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
    /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo<br/>
    /// key.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB change.<br/>
    /// # </weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 128, Variant Id 2
    /// </summary>
    public class CallSetKey : BaseType
    {
        public override string TypeName() => "CallSetKey";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress New { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            New = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
            New.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
