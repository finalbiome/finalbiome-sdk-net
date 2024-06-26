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
    /// Set the balances of a given account.<br/>
    /// <para></para>
    /// This will alter `FreeBalance` and `ReservedBalance` in storage. it will<br/>
    /// also alter the total issuance of the system (`TotalIssuance`) appropriately.<br/>
    /// If the new free or reserved balance is below the existential deposit,<br/>
    /// it will reset the account nonce (`frame_system::AccountNonce`).<br/>
    /// <para></para>
    /// The dispatch origin for this call is `root`.<br/>
    ///
    ///
    /// Generated from meta with Type Id 128, Variant Id 1
    /// </summary>
    public class CallSetBalance : Codec
    {
        public override string TypeName() => "CallSetBalance";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress Who { get; private set; }
        public FinalBiome.Api.Types.CompactU128 NewFree { get; private set; }
        public FinalBiome.Api.Types.CompactU128 NewReserved { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Who = new FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress();
            Who.Decode(byteArray, ref p);

            NewFree = new FinalBiome.Api.Types.CompactU128();
            NewFree.Decode(byteArray, ref p);

            NewReserved = new FinalBiome.Api.Types.CompactU128();
            NewReserved.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
