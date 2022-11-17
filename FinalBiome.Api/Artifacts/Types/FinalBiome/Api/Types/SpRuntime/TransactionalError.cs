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
