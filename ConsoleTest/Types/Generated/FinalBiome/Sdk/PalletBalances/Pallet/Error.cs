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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 125
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Vesting balance too high to send value
    /// </summary>
        VestingBalance,
    /// <summary>
    /// Account liquidity restrictions prevent withdrawal
    /// </summary>
        LiquidityRestrictions,
    /// <summary>
    /// Balance too low to send value
    /// </summary>
        InsufficientBalance,
    /// <summary>
    /// Value too low to create account due to existential deposit
    /// </summary>
        ExistentialDeposit,
    /// <summary>
    /// Transfer/payment would kill account
    /// </summary>
        KeepAlive,
    /// <summary>
    /// A vesting schedule already exists for this account
    /// </summary>
        ExistingVestingSchedule,
    /// <summary>
    /// Beneficiary account must pre-exist
    /// </summary>
        DeadAccount,
    /// <summary>
    /// Number of named reserves exceed MaxReserves
    /// </summary>
        TooManyReserves,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 125
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
