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
    public class TokenError : Enum<InnerTokenError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "TokenError";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
