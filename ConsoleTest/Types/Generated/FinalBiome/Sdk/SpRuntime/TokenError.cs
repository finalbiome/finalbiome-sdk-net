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
    /// Generated from meta with Type Id 24
    /// </summary>
    public enum InnerTokenError
    {
        NoFunds,
        WouldDie,
        BelowMinimum,
        CannotCreate,
        UnknownAsset,
        Frozen,
        Unsupported,
    }
    /// <summary>
    /// Generated from meta with Type Id 24
    /// </summary>
    public class TokenError : BaseEnumExt<InnerTokenError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "TokenError";
    }
}
