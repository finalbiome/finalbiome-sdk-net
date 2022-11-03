///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 32
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// An account was created with some free balance.
    /// </summary>
        Endowed,
    /// <summary>
    /// An account was removed whose balance was non-zero but below ExistentialDeposit,
    /// resulting in an outright loss.
    /// </summary>
        DustLost,
    /// <summary>
    /// Transfer succeeded.
    /// </summary>
        Transfer,
    /// <summary>
    /// A balance was set by root.
    /// </summary>
        BalanceSet,
    /// <summary>
    /// Some balance was reserved (moved from free to reserved).
    /// </summary>
        Reserved,
    /// <summary>
    /// Some balance was unreserved (moved from reserved to free).
    /// </summary>
        Unreserved,
    /// <summary>
    /// Some balance was moved from the reserve of the first account to the second account.
    /// Final argument indicates the destination balance type.
    /// </summary>
        ReserveRepatriated,
    /// <summary>
    /// Some amount was deposited (e.g. for transaction fees).
    /// </summary>
        Deposit,
    /// <summary>
    /// Some amount was withdrawn from the account (e.g. for transaction fees).
    /// </summary>
        Withdraw,
    /// <summary>
    /// Some amount was removed from the account (e.g. for misbehavior).
    /// </summary>
        Slashed,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 32
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, FinalBiome.Sdk.FrameSupport.Traits.Tokens.Misc.BalanceStatus>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>
    {
        public override string TypeName() => "Event";
    }
}
