///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.PalletSupport
{
    /// <summary>
    /// Generated from meta with Type Id 136
    /// </summary>
    public class Attribute : Codec
    {
        public override string TypeName() => "Attribute";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.BoundedVecU8 Key { get; private set; }
        public FinalBiome.Api.Types.PalletSupport.AttributeValue Value { get; private set; }
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

            Key = new FinalBiome.Api.Types.BoundedVecU8();
            Key.Decode(byteArray, ref p);

            Value = new FinalBiome.Api.Types.PalletSupport.AttributeValue();
            Value.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
