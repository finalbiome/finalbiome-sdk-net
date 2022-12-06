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
namespace FinalBiome.Api.Types
{
    /// <summary>
    /// Generated from meta with Type Id 123
    /// </summary>
    public class Array20U8 : Codec
    {
        public override int TypeSize => 20;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U8[] Value  { get; internal set; }
#pragma warning restore CS8618
        public override string TypeName() => $"[{new FinalBiome.Api.Types.Primitive.U8().TypeName()}; {this.TypeSize}]";

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value) { result.AddRange(v.Encode()); };
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int pos)
        {
            var start = pos;
            var array = new FinalBiome.Api.Types.Primitive.U8[TypeSize];
            for (var i = 0; i < array.Length; i++) { var t = new FinalBiome.Api.Types.Primitive.U8(); t.Decode(byteArray, ref pos); array[i] = t; };
            var bytesLength = pos - start;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public void Init(FinalBiome.Api.Types.Primitive.U8[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
