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
namespace FinalBiome.Api.Types.SpRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 22
    /// </summary>
    public enum InnerDispatchError : byte
    {
        Other = 0,
        CannotLookup = 1,
        BadOrigin = 2,
        Module = 3,
        ConsumerRemaining = 4,
        NoProviders = 5,
        TooManyConsumers = 6,
        Token = 7,
        Arithmetic = 8,
        Transactional = 9,
    }
    /// <summary>
    /// Generated from meta with Type Id 22
    /// </summary>
    public class DispatchError : Enum<InnerDispatchError, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Api.Types.SpRuntime.ModuleError, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Api.Types.SpRuntime.TokenError, FinalBiome.Api.Types.SpRuntime.ArithmeticError, FinalBiome.Api.Types.SpRuntime.TransactionalError>
    {
        public override string TypeName() => "DispatchError";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
