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
    /// Kill all storage items with a key that starts with the given prefix.<br/>
    /// <para></para>
    /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under<br/>
    /// the prefix we are removing to accurately calculate the weight of this function.<br/>
    ///
    ///
    /// Generated from meta with Type Id 76, Variant Id 7
    /// </summary>
    public class CallKillPrefix : Codec
    {
        public override string TypeName() => "CallKillPrefix";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.VecU8 Prefix { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 Subkeys { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Prefix = new FinalBiome.Api.Types.VecU8();
            Prefix.Decode(byteArray, ref p);

            Subkeys = new FinalBiome.Api.Types.Primitive.U32();
            Subkeys.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
