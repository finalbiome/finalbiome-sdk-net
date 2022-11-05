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
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 32
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// An account was created with some free balance.<br/>
    /// </summary>
        Endowed,
    /// <summary>
    /// An account was removed whose balance was non-zero but below ExistentialDeposit,<br/>
    /// resulting in an outright loss.<br/>
    /// </summary>
        DustLost,
    /// <summary>
    /// Transfer succeeded.<br/>
    /// </summary>
        Transfer,
    /// <summary>
    /// A balance was set by root.<br/>
    /// </summary>
        BalanceSet,
    /// <summary>
    /// Some balance was reserved (moved from free to reserved).<br/>
    /// </summary>
        Reserved,
    /// <summary>
    /// Some balance was unreserved (moved from reserved to free).<br/>
    /// </summary>
        Unreserved,
    /// <summary>
    /// Some balance was moved from the reserve of the first account to the second account.<br/>
    /// Final argument indicates the destination balance type.<br/>
    /// </summary>
        ReserveRepatriated,
    /// <summary>
    /// Some amount was deposited (e.g. for transaction fees).<br/>
    /// </summary>
        Deposit,
    /// <summary>
    /// Some amount was withdrawn from the account (e.g. for transaction fees).<br/>
    /// </summary>
        Withdraw,
    /// <summary>
    /// Some amount was removed from the account (e.g. for misbehavior).<br/>
    /// </summary>
        Slashed,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 32
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128, FinalBiome.Sdk.FrameSupport.Traits.Tokens.Misc.BalanceStatus>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>
    {
        public override string TypeName() => "Event";
    }
}
