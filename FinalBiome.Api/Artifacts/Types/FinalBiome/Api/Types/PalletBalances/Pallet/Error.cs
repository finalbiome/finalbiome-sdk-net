///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///

#pragma warning disable IDE0090
#pragma warning disable CA1822
#pragma warning disable IDE0028
#pragma warning disable IDE0052
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletBalances.Pallet
{
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 133
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// Vesting balance too high to send value<br/>
    /// </summary>
        VestingBalance = 0,
    /// <summary>
    /// Account liquidity restrictions prevent withdrawal<br/>
    /// </summary>
        LiquidityRestrictions = 1,
    /// <summary>
    /// Balance too low to send value<br/>
    /// </summary>
        InsufficientBalance = 2,
    /// <summary>
    /// Value too low to create account due to existential deposit<br/>
    /// </summary>
        ExistentialDeposit = 3,
    /// <summary>
    /// Transfer/payment would kill account<br/>
    /// </summary>
        KeepAlive = 4,
    /// <summary>
    /// A vesting schedule already exists for this account<br/>
    /// </summary>
        ExistingVestingSchedule = 5,
    /// <summary>
    /// Beneficiary account must pre-exist<br/>
    /// </summary>
        DeadAccount = 6,
    /// <summary>
    /// Number of named reserves exceed MaxReserves<br/>
    /// </summary>
        TooManyReserves = 7,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 133
    /// </summary>
    public class Error : Enum<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
