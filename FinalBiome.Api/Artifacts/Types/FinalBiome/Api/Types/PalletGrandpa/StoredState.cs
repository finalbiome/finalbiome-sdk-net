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
namespace FinalBiome.Api.Types.PalletGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 102
    /// </summary>
    public enum InnerStoredState : byte
    {
        Live = 0,
        PendingPause = 1,
        Paused = 2,
        PendingResume = 3,
    }
    /// <summary>
    /// Generated from meta with Type Id 102
    /// </summary>
    public class StoredState : Enum<InnerStoredState, BaseVoid, FinalBiome.Api.Types.PalletGrandpa.StoredStatePendingPause, BaseVoid, FinalBiome.Api.Types.PalletGrandpa.StoredStatePendingResume>
    {
        public override string TypeName() => "StoredState";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
