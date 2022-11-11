///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport
{
    /// <summary>
    /// Generated from meta with Type Id 136
    /// </summary>
    public class Attribute : BaseComposite
    {
        public override string TypeName() => "Attribute";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.BoundedVecU8 Key { get; private set; }
        public FinalBiome.Sdk.PalletSupport.AttributeValue Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Key.Encode());
            bytes.AddRange(Value.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Key = new FinalBiome.Sdk.BoundedVecU8();
            Key.Decode(byteArray, ref p);

            Value = new FinalBiome.Sdk.PalletSupport.AttributeValue();
            Value.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
