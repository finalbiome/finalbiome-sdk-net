///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpArithmetic.FixedPoint
{
    /// <summary>
    /// Generated from meta with Type Id 126
    /// </summary>
    public class FixedU128 : FinalBiome.Api.Types.Primitive.U128
    {
        public override string TypeName() => "FixedU128";
        public static implicit operator BigInteger(FixedU128 v) => v.Value;
        public static implicit operator FixedU128(BigInteger v) {
            FixedU128 res = new();
            res.Init(v);
            return res;
        }
    }
}
