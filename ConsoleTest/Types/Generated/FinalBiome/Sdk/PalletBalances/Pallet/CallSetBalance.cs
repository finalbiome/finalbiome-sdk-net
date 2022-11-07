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
    /// Generated from meta with Type Id 120, Variant Id 1
    /// </summary>
    public class CallSetBalance : BaseType
    {
        public override string TypeName() => "CallSetBalance";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress Who { get; private set; }
        public FinalBiome.Sdk.CompactU128 NewFree { get; private set; }
        public FinalBiome.Sdk.CompactU128 NewReserved { get; private set; }
#pragma warning restore CS8618

        public override byte[] Encode()
        {
            throw new NotImplementedException();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;

            Who = new FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress();
            Who.Decode(byteArray, ref p);

            NewFree = new FinalBiome.Sdk.CompactU128();
            NewFree.Decode(byteArray, ref p);

            NewReserved = new FinalBiome.Sdk.CompactU128();
            NewReserved.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
