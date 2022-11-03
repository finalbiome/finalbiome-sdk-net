///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.SpRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 23
    /// </summary>
    public class ModuleError : BaseType
    {
        public override string TypeName() => "ModuleError";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public Ajuna.NetApi.Model.Types.Primitive.U8 Index { get; private set; }
        public FinalBiome.Sdk.Model.Types.Base.Array4U8 Error { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Index = new Ajuna.NetApi.Model.Types.Primitive.U8();
            Index.Decode(byteArray, ref p);

            Error = new FinalBiome.Sdk.Model.Types.Base.Array4U8();
            Error.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
