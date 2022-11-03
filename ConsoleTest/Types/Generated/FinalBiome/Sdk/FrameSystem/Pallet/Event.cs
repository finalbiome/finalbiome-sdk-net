///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSystem.Pallet
{
    /// <summary>
    /// Event for the System pallet.
    ///
    ///
    /// Generated from meta with Type Id 18
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// An extrinsic completed successfully.
    /// </summary>
        ExtrinsicSuccess,
    /// <summary>
    /// An extrinsic failed.
    /// </summary>
        ExtrinsicFailed,
    /// <summary>
    /// `:code` was updated.
    /// </summary>
        CodeUpdated,
    /// <summary>
    /// A new account was created.
    /// </summary>
        NewAccount,
    /// <summary>
    /// An account was reaped.
    /// </summary>
        KilledAccount,
    /// <summary>
    /// On on-chain remark happened.
    /// </summary>
        Remarked,
    }
    /// <summary>
    /// Event for the System pallet.
    ///
    ///
    /// Generated from meta with Type Id 18
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.FrameSupport.Weights.DispatchInfo, BaseTuple<FinalBiome.Sdk.SpRuntime.DispatchError, FinalBiome.Sdk.FrameSupport.Weights.DispatchInfo>, BaseVoid, FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.PrimitiveTypes.H256>>
    {
        public override string TypeName() => "Event";
    }
}
