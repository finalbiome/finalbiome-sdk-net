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
    /// This function does not check the weight of the call, and instead allows the<br/>
    /// Sudo user to specify the weight of the call.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - O(1).<br/>
    /// - The weight of this call is defined by the caller.<br/>
    /// # </weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 128, Variant Id 1
    /// </summary>
    public class CallSudoUncheckedWeight : BaseType
    {
        public override string TypeName() => "CallSudoUncheckedWeight";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.FinalbiomeNodeRuntime.Call Call { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U64 Weight { get; private set; }
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

            Weight = new Ajuna.NetApi.Model.Types.Primitive.U64();
            Weight.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
