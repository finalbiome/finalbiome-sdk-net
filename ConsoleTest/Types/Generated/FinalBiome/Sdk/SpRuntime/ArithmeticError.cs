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
    /// Generated from meta with Type Id 25
    /// </summary>
    public enum InnerArithmeticError
    {
        Underflow,
        Overflow,
        DivisionByZero,
    }
    /// <summary>
    /// Generated from meta with Type Id 25
    /// </summary>
    public class ArithmeticError : BaseEnumExt<InnerArithmeticError, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "ArithmeticError";
    }
}
