///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.SpFinalityGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 100
    /// </summary>
    public enum InnerEquivocation : byte
    {
        Prevote = 0,
        Precommit = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 100
    /// </summary>
    public class Equivocation : Enum<InnerEquivocation, FinalBiome.Api.Types.FinalityGrandpa.Equivocation, FinalBiome.Api.Types.FinalityGrandpa.Equivocation>
    {
        public override string TypeName() => "Equivocation";
    }
}
