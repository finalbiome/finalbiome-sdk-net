///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 52
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// Mechanics done.
    /// </summary>
        Finished,
    /// <summary>
    /// Mechanics was stopped.
    /// </summary>
        Stopped,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 52
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.Model.Types.Base.OptionEventMechanicResultData>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.PalletMechanics.Types.EventMechanicStopReason>>
    {
        public override string TypeName() => "Event";
    }
}
