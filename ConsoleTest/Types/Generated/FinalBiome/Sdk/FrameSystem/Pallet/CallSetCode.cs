///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Pallet
{
    /// <summary>
    /// Set the new runtime code.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - `O(C + S)` where `C` length of `code` and `S` complexity of `can_set_code`<br/>
    /// - 1 call to `can_set_code`: `O(S)` (calls `sp_io::misc::runtime_version` which is<br/>
    ///   expensive).<br/>
    /// - 1 storage write (codec `O(C)`).<br/>
    /// - 1 digest item.<br/>
    /// - 1 event.<br/>
    /// The weight of this function is dependent on the runtime, but generally this is very<br/>
    /// expensive. We will treat this as a full block.<br/>
    /// # </weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 3
    /// </summary>
    public class CallSetCode : BaseType
    {
        public override string TypeName() => "CallSetCode";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.VecU8 Code { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Code = new FinalBiome.Sdk.VecU8();
            Code.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
