///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
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
