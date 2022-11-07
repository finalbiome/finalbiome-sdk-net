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
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB write (event).<br/>
    /// - Weight of derivative `call` execution + 10,000.<br/>
    /// # </weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 128, Variant Id 0
    /// </summary>
    public class CallSudo : BaseType
    {
        public override string TypeName() => "CallSudo";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.FinalbiomeNodeRuntime.Call Call { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Call = new FinalBiome.Sdk.FinalbiomeNodeRuntime.Call();
            Call.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
