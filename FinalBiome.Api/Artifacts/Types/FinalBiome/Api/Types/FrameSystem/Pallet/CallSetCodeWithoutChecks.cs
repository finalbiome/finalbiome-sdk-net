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
namespace FinalBiome.Api.Types.FrameSystem.Pallet
{
    /// <summary>
    /// Set the new runtime code without doing any checks of the given `code`.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - `O(C)` where `C` length of `code`<br/>
    /// - 1 storage write (codec `O(C)`).<br/>
    /// - 1 digest item.<br/>
    /// - 1 event.<br/>
    /// The weight of this function is dependent on the runtime. We will treat this as a full<br/>
    /// block. # &lt;/weight&gt;<br/>
    ///
    ///
    /// Generated from meta with Type Id 76, Variant Id 4
    /// </summary>
    public class CallSetCodeWithoutChecks : Codec
    {
        public override string TypeName() => "CallSetCodeWithoutChecks";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.VecU8 Code { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Code = new FinalBiome.Api.Types.VecU8();
            Code.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
