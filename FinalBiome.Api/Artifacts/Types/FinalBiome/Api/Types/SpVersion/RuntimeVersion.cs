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
namespace FinalBiome.Api.Types.SpVersion
{
    /// <summary>
    /// Generated from meta with Type Id 80
    /// </summary>
    public class RuntimeVersion : Codec
    {
        public override string TypeName() => "RuntimeVersion";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.Primitive.Str SpecName { get; private set; }
        public FinalBiome.Api.Types.Primitive.Str ImplName { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 AuthoringVersion { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 SpecVersion { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 ImplVersion { get; private set; }
        public FinalBiome.Api.Types.Cow Apis { get; private set; }
        public FinalBiome.Api.Types.Primitive.U32 TransactionVersion { get; private set; }
        public FinalBiome.Api.Types.Primitive.U8 StateVersion { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(SpecName.Encode());
            bytes.AddRange(ImplName.Encode());
            bytes.AddRange(AuthoringVersion.Encode());
            bytes.AddRange(SpecVersion.Encode());
            bytes.AddRange(ImplVersion.Encode());
            bytes.AddRange(Apis.Encode());
            bytes.AddRange(TransactionVersion.Encode());
            bytes.AddRange(StateVersion.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            SpecName = new FinalBiome.Api.Types.Primitive.Str();
            SpecName.Decode(byteArray, ref p);

            ImplName = new FinalBiome.Api.Types.Primitive.Str();
            ImplName.Decode(byteArray, ref p);

            AuthoringVersion = new FinalBiome.Api.Types.Primitive.U32();
            AuthoringVersion.Decode(byteArray, ref p);

            SpecVersion = new FinalBiome.Api.Types.Primitive.U32();
            SpecVersion.Decode(byteArray, ref p);

            ImplVersion = new FinalBiome.Api.Types.Primitive.U32();
            ImplVersion.Decode(byteArray, ref p);

            Apis = new FinalBiome.Api.Types.Cow();
            Apis.Decode(byteArray, ref p);

            TransactionVersion = new FinalBiome.Api.Types.Primitive.U32();
            TransactionVersion.Decode(byteArray, ref p);

            StateVersion = new FinalBiome.Api.Types.Primitive.U8();
            StateVersion.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
