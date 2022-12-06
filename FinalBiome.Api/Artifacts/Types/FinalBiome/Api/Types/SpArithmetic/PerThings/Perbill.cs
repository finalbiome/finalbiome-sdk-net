///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpArithmetic.PerThings
{
    /// <summary>
    /// Generated from meta with Type Id 69
    /// </summary>
    public class Perbill : FinalBiome.Api.Types.Primitive.U32
    {
        public override string TypeName() => "Perbill";
        public static implicit operator uint(Perbill v) => v.Value;
        public static implicit operator Perbill(uint v) {
            Perbill res = new();
            res.Init(v);
            return res;
        }
    }
}
