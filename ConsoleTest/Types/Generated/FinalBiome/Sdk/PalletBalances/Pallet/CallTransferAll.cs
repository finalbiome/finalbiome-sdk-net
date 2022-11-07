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
    /// Transfer the entire transferable balance from the caller account.<br/>
    /// <para></para>
    /// NOTE: This function only attempts to transfer _transferable_ balances. This means that<br/>
    /// any locked, reserved, or existential deposits (when `keep_alive` is `true`), will not be<br/>
    /// transferred by this function. To ensure that this function results in a killed account,<br/>
    /// you might need to prepare the account by removing any reference counters, storage<br/>
    /// deposits, etc...<br/>
    /// <para></para>
    /// The dispatch origin of this call must be Signed.<br/>
    /// <para></para>
    /// - `dest`: The recipient of the transfer.<br/>
    /// - `keep_alive`: A boolean to determine if the `transfer_all` operation should send all<br/>
    ///   of the funds the account has, causing the sender account to be killed (false), or<br/>
    ///   transfer everything except at least the existential deposit, which will guarantee to<br/>
    ///   keep the sender account alive (true). # <weight><br/>
    /// - O(1). Just like transfer, but reading the user's transferable balance first.<br/>
    ///   #</weight><br/>
    ///
    ///
    /// Generated from meta with Type Id 120, Variant Id 4
    /// </summary>
    public class CallTransferAll : BaseType
    {
        public override string TypeName() => "CallTransferAll";

        private int _size;
        public override int TypeSize => _size;
#pragma warning disable CS8618
        public FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress Dest { get; private set; }
        public Ajuna.NetApi.Model.Types.Primitive.Bool KeepAlive { get; private set; }
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

            KeepAlive = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            KeepAlive.Decode(byteArray, ref p);

            _size = p - start;
        }
    }
}
