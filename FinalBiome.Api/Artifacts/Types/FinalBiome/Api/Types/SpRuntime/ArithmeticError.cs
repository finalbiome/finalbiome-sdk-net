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
    /// Generated from meta with Type Id 25
    /// </summary>
    public enum InnerArithmeticError : byte
    {
        Underflow = 0,
        Overflow = 1,
        DivisionByZero = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 25
    /// </summary>
    public class ArithmeticError : Enum<InnerArithmeticError, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "ArithmeticError";
    }
}
