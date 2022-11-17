///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.FrameSystem
{
    /// <summary>
    /// Generated from meta with Type Id 60
    /// </summary>
    public enum InnerPhase : byte
    {
        ApplyExtrinsic = 0,
        Finalization = 1,
        Initialization = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 60
    /// </summary>
    public class Phase : Enum<InnerPhase, FinalBiome.Api.Types.Primitive.U32, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Phase";
    }
}
