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
    /// Kill all storage items with a key that starts with the given prefix.<br/>
    /// <para></para>
    /// **NOTE:** We rely on the Root origin to provide us the number of subkeys under<br/>
    /// the prefix we are removing to accurately calculate the weight of this function.<br/>
    ///
    ///
    /// Generated from meta with Type Id 68, Variant Id 7
    /// </summary>
    public class CallKillPrefix : BaseType
    {
        public override string TypeName() => "CallKillPrefix";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.VecU8 Prefix { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 Subkeys { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Prefix = new FinalBiome.Sdk.VecU8();
            Prefix.Decode(byteArray, ref p);

            Subkeys = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Subkeys.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
