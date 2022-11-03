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
    public class NumberAttribute : BaseType
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
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            NumberValue = new Ajuna.NetApi.Model.Types.Primitive.U32();
            NumberValue.Decode(byteArray, ref p);

            NumberMax = new FinalBiome.Sdk.Model.Types.Base.OptionU32();
            NumberMax.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
