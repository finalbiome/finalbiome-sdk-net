///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.SpFinalityGrandpa
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
    public class Equivocation : BaseEnumExt<InnerEquivocation, FinalBiome.Sdk.FinalityGrandpa.Equivocation, FinalBiome.Sdk.FinalityGrandpa.Equivocation>
    {
        public override string TypeName() => "Equivocation";
    }
}
