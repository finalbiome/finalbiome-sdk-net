///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletMechanics.Types
{
    /// <summary>
    /// Generated from meta with Type Id 58
    /// </summary>
    public enum InnerBetResult : byte
    {
        Won = 0,
        Lost = 1,
        Draw = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 58
    /// </summary>
    public class BetResult : Enum<InnerBetResult, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "BetResult";
    }
}
