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
    /// Generated from meta with Type Id 26
    /// </summary>
    public enum InnerTransactionalError : byte
    {
        LimitReached = 0,
        NoLayer = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 26
    /// </summary>
    public class TransactionalError : Enum<InnerTransactionalError, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "TransactionalError";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
