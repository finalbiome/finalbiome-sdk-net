///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletBalances.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 32
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// An account was created with some free balance.<br/>
    /// </summary>
        Endowed = 0,
    /// <summary>
    /// An account was removed whose balance was non-zero but below ExistentialDeposit,<br/>
    /// resulting in an outright loss.<br/>
    /// </summary>
        DustLost = 1,
    /// <summary>
    /// Transfer succeeded.<br/>
    /// </summary>
        Transfer = 2,
    /// <summary>
    /// A balance was set by root.<br/>
    /// </summary>
        BalanceSet = 3,
    /// <summary>
    /// Some balance was reserved (moved from free to reserved).<br/>
    /// </summary>
        Reserved = 4,
    /// <summary>
    /// Some balance was unreserved (moved from reserved to free).<br/>
    /// </summary>
        Unreserved = 5,
    /// <summary>
    /// Some balance was moved from the reserve of the first account to the second account.<br/>
    /// Final argument indicates the destination balance type.<br/>
    /// </summary>
        ReserveRepatriated = 6,
    /// <summary>
    /// Some amount was deposited (e.g. for transaction fees).<br/>
    /// </summary>
        Deposit = 7,
    /// <summary>
    /// Some amount was withdrawn from the account (e.g. for transaction fees).<br/>
    /// </summary>
        Withdraw = 8,
    /// <summary>
    /// Some amount was removed from the account (e.g. for misbehavior).<br/>
    /// </summary>
        Slashed = 9,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 32
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletBalances.Pallet.EventEndowed, FinalBiome.Api.Types.PalletBalances.Pallet.EventDustLost, FinalBiome.Api.Types.PalletBalances.Pallet.EventTransfer, FinalBiome.Api.Types.PalletBalances.Pallet.EventBalanceSet, FinalBiome.Api.Types.PalletBalances.Pallet.EventReserved, FinalBiome.Api.Types.PalletBalances.Pallet.EventUnreserved, FinalBiome.Api.Types.PalletBalances.Pallet.EventReserveRepatriated, FinalBiome.Api.Types.PalletBalances.Pallet.EventDeposit, FinalBiome.Api.Types.PalletBalances.Pallet.EventWithdraw, FinalBiome.Api.Types.PalletBalances.Pallet.EventSlashed>
    {
        public override string TypeName() => "Event";
    }
}
