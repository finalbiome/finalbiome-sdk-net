///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using FinalBiome.Sdk.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances.Pallet
{
    /// <summary>
    /// Same as the [`transfer`] call, but with a check that the transfer will not kill the<br/>
    /// origin account.<br/>
    /// <para></para>
    /// 99% of the time you want [`transfer`] instead.<br/>
    /// <para></para>
    /// [`transfer`]: struct.Pallet.html#method.transfer<br/>
    ///
    ///
    /// Generated from meta with Type Id 120, Variant Id 3
    /// </summary>
    public class CallTransferKeepAlive : BaseType
    {
        public override string TypeName() => "CallTransferKeepAlive";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress Dest { get; private set; }
        public FinalBiome.Sdk.CompactU128 Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Dest = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
            Dest.Decode(byteArray, ref p);

            Value = new FinalBiome.Sdk.CompactU128();
            Value.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
