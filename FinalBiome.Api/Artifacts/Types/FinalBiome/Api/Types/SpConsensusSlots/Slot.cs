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
namespace FinalBiome.Api.Types.SpConsensusSlots
{
    /// <summary>
    /// Generated from meta with Type Id 101
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

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
