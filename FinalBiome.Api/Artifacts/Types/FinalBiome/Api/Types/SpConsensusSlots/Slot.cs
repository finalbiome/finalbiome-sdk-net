///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpConsensusSlots
{
    /// <summary>
    /// Generated from meta with Type Id 94
    /// </summary>
    public class Slot : FinalBiome.Api.Types.Primitive.U64
    {
        public override string TypeName() => "Slot";
        public static implicit operator ulong(Slot v) => v.Value;
        public static implicit operator Slot(ulong v) {
            Slot res = new();
            res.Init(v);
            return res;
        }
    }
}
