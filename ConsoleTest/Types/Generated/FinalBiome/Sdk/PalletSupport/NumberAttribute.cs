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
    /// Generated from meta with Type Id 49
    /// </summary>
    public class NumberAttribute : BaseComposite
    {
        public override string TypeName() => "NumberAttribute";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U32 NumberValue { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.OptionU32 NumberMax { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            var bytes = new List<byte>();
            bytes.AddRange(NumberValue.Encode());
            bytes.AddRange(NumberMax.Encode());
            return bytes.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            NumberValue = new Ajuna.NetApi.Model.Types.Primitive.U32();
            NumberValue.Decode(byteArray, ref p);

            NumberMax = new FinalBiome.Sdk.Model.Types.Base.OptionU32();
            NumberMax.Decode(byteArray, ref p);

            _size = p - start;
            Bytes = new byte[TypeSize];
            Array.Copy(byteArray, start, Bytes, 0, TypeSize);
        }
    }
}
