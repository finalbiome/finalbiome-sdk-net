///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
namespace FinalBiome.Api.Types.SpRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 23
    /// </summary>
    public class ModuleError : Codec
    {
        public override string TypeName() => "ModuleError";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.U8 Index { get; private set; }
        public FinalBiome.Api.Types.Array4U8 Error { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(Index.Encode());
            bytes.AddRange(Error.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Index = new FinalBiome.Api.Types.Primitive.U8();
            Index.Decode(byteArray, ref p);

            Error = new FinalBiome.Api.Types.Array4U8();
            Error.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
