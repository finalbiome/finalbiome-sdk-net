///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.SpRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 22
    /// </summary>
    public enum InnerDispatchError
    {
        Other,
        CannotLookup,
        BadOrigin,
        Module,
        ConsumerRemaining,
        NoProviders,
        TooManyConsumers,
        Token,
        Arithmetic,
        Transactional,
    }
    /// <summary>
    /// Generated from meta with Type Id 22
    /// </summary>
    public class DispatchError : BaseEnumExt<InnerDispatchError, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Sdk.SpRuntime.ModuleError, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Sdk.SpRuntime.TokenError, FinalBiome.Sdk.SpRuntime.ArithmeticError, FinalBiome.Sdk.SpRuntime.TransactionalError>
    {
        public override string TypeName() => "DispatchError";
    }
}
