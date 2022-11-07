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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 125
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Vesting balance too high to send value<br/>
    /// </summary>
        VestingBalance,
    /// <summary>
    /// Account liquidity restrictions prevent withdrawal<br/>
    /// </summary>
        LiquidityRestrictions,
    /// <summary>
    /// Balance too low to send value<br/>
    /// </summary>
        InsufficientBalance,
    /// <summary>
    /// Value too low to create account due to existential deposit<br/>
    /// </summary>
        ExistentialDeposit,
    /// <summary>
    /// Transfer/payment would kill account<br/>
    /// </summary>
        KeepAlive,
    /// <summary>
    /// A vesting schedule already exists for this account<br/>
    /// </summary>
        ExistingVestingSchedule,
    /// <summary>
    /// Beneficiary account must pre-exist<br/>
    /// </summary>
        DeadAccount,
    /// <summary>
    /// Number of named reserves exceed MaxReserves<br/>
    /// </summary>
        TooManyReserves,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 125
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}