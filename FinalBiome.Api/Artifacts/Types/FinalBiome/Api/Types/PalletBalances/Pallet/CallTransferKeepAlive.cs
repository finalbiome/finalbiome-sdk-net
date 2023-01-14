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
namespace FinalBiome.Api.Types.PalletBalances.Pallet
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
    /// Generated from meta with Type Id 128, Variant Id 3
    /// </summary>
    public class CallTransferKeepAlive : Codec
    {
        public override string TypeName() => "CallTransferKeepAlive";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress Dest { get; private set; }
        public FinalBiome.Api.Types.CompactU128 Value { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Dest = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            Dest.Decode(byteArray, ref p);

            Value = new FinalBiome.Api.Types.CompactU128();
            Value.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
