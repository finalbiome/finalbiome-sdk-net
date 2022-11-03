///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.Model.Types.Base
{
    /// <summary>
    /// Generated from meta with Type Id 14
    /// </summary>
    public class Array4U8 : BaseType
    {
#pragma warning disable CS8618
        private Ajuna.NetApi.Model.Types.Primitive.U8[] _value;
#pragma warning restore CS8618

        public override int TypeSize
        {
            get { return 4; }
        }

        public Ajuna.NetApi.Model.Types.Primitive.U8[] Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        public override string TypeName()
        {
            return string.Format("[{0}; {1}]", new Ajuna.NetApi.Model.Types.Primitive.U8().TypeName(), this.TypeSize);
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value) { result.AddRange(v.Encode()); };
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var array = new Ajuna.NetApi.Model.Types.Primitive.U8[TypeSize];
            for (var i = 0; i < array.Length; i++) { var t = new Ajuna.NetApi.Model.Types.Primitive.U8(); t.Decode(byteArray, ref p); array[i] = t; };
            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public void Create(Ajuna.NetApi.Model.Types.Primitive.U8[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }
}
