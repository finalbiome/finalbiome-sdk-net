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
    public enum InnerTokenError : byte
    {
        NoFunds = 0,
        WouldDie = 1,
        BelowMinimum = 2,
        CannotCreate = 3,
        UnknownAsset = 4,
        Frozen = 5,
        Unsupported = 6,
    }
    /// <summary>
    /// Generated from meta with Type Id 24
    /// </summary>
    public class TokenError : BaseEnumExt<InnerTokenError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "TokenError";
    }
}
