///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSudo.Pallet
{
    /// <summary>
    /// A sudo just took place. \[result\]<br/>
    ///
    ///
    /// Generated from meta with Type Id 35, Variant Id 0
    /// </summary>
    public class EventSudid : BaseType
    {
        public override string TypeName() => "EventSudid";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.Model.Types.Base.ResultTuple_Empty_DispatchError SudoResult { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            SudoResult = new FinalBiome.Sdk.Model.Types.Base.ResultTuple_Empty_DispatchError();
            SudoResult.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
