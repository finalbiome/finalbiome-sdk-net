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
namespace FinalBiome.Api.Types.SpFinalityGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 107
    /// </summary>
    public enum InnerEquivocation : byte
    {
        Prevote = 0,
        Precommit = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 107
    /// </summary>
    public class Equivocation : Enum<InnerEquivocation, FinalBiome.Api.Types.FinalityGrandpa.Equivocation, FinalBiome.Api.Types.FinalityGrandpa.Equivocation>
    {
        public override string TypeName() => "Equivocation";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
