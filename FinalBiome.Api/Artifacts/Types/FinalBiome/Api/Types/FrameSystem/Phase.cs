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
namespace FinalBiome.Api.Types.FrameSystem
{
    /// <summary>
    /// Generated from meta with Type Id 68
    /// </summary>
    public enum InnerPhase : byte
    {
        ApplyExtrinsic = 0,
        Finalization = 1,
        Initialization = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 68
    /// </summary>
    public class Phase : Enum<InnerPhase, FinalBiome.Api.Types.Primitive.U32, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Phase";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
