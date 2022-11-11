///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.SpVersion
{
    /// <summary>
    /// Generated from meta with Type Id 80
    /// </summary>
    public class RuntimeVersion : BaseComposite
    {
        public override string TypeName() => "RuntimeVersion";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.Str SpecName { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.Str ImplName { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 AuthoringVersion { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 SpecVersion { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 ImplVersion { get; private set; }
        public FinalBiome.Sdk.Cow Apis { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U32 TransactionVersion { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.U8 StateVersion { get; private set; }
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

            SpecName = new Ajuna.NetApi.Model.Types.Primitive.Str();
            SpecName.Decode(byteArray, ref p);

            ImplName = new Ajuna.NetApi.Model.Types.Primitive.Str();
            ImplName.Decode(byteArray, ref p);

            AuthoringVersion = new Ajuna.NetApi.Model.Types.Primitive.U32();
            AuthoringVersion.Decode(byteArray, ref p);

            SpecVersion = new Ajuna.NetApi.Model.Types.Primitive.U32();
            SpecVersion.Decode(byteArray, ref p);

            ImplVersion = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ImplVersion.Decode(byteArray, ref p);

            Apis = new FinalBiome.Sdk.Cow();
            Apis.Decode(byteArray, ref p);

            TransactionVersion = new Ajuna.NetApi.Model.Types.Primitive.U32();
            TransactionVersion.Decode(byteArray, ref p);

            StateVersion = new Ajuna.NetApi.Model.Types.Primitive.U8();
            StateVersion.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
