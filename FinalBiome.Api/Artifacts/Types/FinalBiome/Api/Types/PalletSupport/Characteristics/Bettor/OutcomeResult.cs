///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport.Characteristics.Bettor
{
    /// <summary>
    /// Generated from meta with Type Id 152
    /// </summary>
    public enum InnerOutcomeResult : byte
    {
        Win = 0,
        Lose = 1,
        Draw = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 152
    /// </summary>
    public class OutcomeResult : Enum<InnerOutcomeResult, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "OutcomeResult";
    }
}
