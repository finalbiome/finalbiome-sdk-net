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
namespace FinalBiome.Api.Types.PalletUsers.Pallet
{
    /// <summary>
    /// Errors of the Users pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// Sender must be the Registrar account<br/>
    /// </summary>
        RequireRegistrar = 0,
    /// <summary>
    /// Exceeded account limit per slot.<br/>
    /// </summary>
        Exhausted = 1,
    /// <summary>
    /// The account is already registered.<br/>
    /// </summary>
        Registered = 2,
    /// <summary>
    /// The provided signature is invalid.<br/>
    /// </summary>
        InvalidSignature = 3,
    /// <summary>
    /// Registrar not defined.<br/>
    /// </summary>
        UnknownRegistrar = 4,
    }
    /// <summary>
    /// Errors of the Users pallet.<br/>
    ///
    ///
    /// Generated from meta with Type Id 180
    /// </summary>
    public class Error : Enum<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
