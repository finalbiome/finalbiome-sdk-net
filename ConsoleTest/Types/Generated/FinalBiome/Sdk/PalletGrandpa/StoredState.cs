///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletGrandpa
{
    /// <summary>
    /// Generated from meta with Type Id 95
    /// </summary>
    public enum InnerStoredState
    {
        Live,
        PendingPause,
        Paused,
        PendingResume,
    }
    /// <summary>
    /// Generated from meta with Type Id 95
    /// </summary>
    public class StoredState : BaseEnumExt<InnerStoredState, BaseVoid, FinalBiome.Sdk.PalletGrandpa.StoredStatePendingPause, BaseVoid, FinalBiome.Sdk.PalletGrandpa.StoredStatePendingResume>
    {
        public override string TypeName() => "StoredState";
    }
}