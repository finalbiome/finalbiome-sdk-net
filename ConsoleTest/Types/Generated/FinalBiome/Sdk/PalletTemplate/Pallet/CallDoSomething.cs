///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletTemplate.Pallet
{
    /// <summary>
    /// An example dispatchable that takes a singles value as a parameter, writes the value to<br/>
    /// storage and emits an event. This function must be dispatched by a signed extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 130, Variant Id 0
    /// </summary>
    public class CallDoSomething : BaseType
    {
        public override string TypeName() => "CallDoSomething";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U32 Something { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Something = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Something.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
