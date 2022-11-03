///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem
{
    /// <summary>
    /// Generated from meta with Type Id 60
    /// </summary>
    public enum InnerPhase
    {
        ApplyExtrinsic,
        Finalization,
        Initialization,
    }
    /// <summary>
    /// Generated from meta with Type Id 60
    /// </summary>
    public class Phase : BaseEnumExt<InnerPhase, Ajuna.NetApi.Model.Types.Primitive.U32, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Phase";
    }
}
