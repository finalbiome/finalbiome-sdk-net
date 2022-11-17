///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletSudo.Pallet
{
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
    /// This function does not check the weight of the call, and instead allows the<br/>
    /// Sudo user to specify the weight of the call.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - The weight of this call is defined by the caller.<br/>
    /// # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 128, Variant Id 1
    /// </summary>
    public class CallSudoUncheckedWeight : Codec
    {
        public override string TypeName() => "CallSudoUncheckedWeight";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.FinalbiomeNodeRuntime.Call Call { get; private set; }
        public FinalBiome.Api.Types.Primitive.U64 Weight { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Call = new FinalBiome.Api.Types.FinalbiomeNodeRuntime.Call();
            Call.Decode(byteArray, ref p);

            Weight = new FinalBiome.Api.Types.Primitive.U64();
            Weight.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
