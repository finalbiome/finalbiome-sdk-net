///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 95
    /// </summary>
    public enum InnerStoredState : byte
    {
        Live = 0,
        PendingPause = 1,
        Paused = 2,
        PendingResume = 3,
    }
    /// <summary>
    /// Generated from meta with Type Id 95
    /// </summary>
    public class StoredState : Enum<InnerStoredState, BaseVoid, FinalBiome.Api.Types.PalletGrandpa.StoredStatePendingPause, BaseVoid, FinalBiome.Api.Types.PalletGrandpa.StoredStatePendingResume>
    {
        public override string TypeName() => "StoredState";
    }
}
