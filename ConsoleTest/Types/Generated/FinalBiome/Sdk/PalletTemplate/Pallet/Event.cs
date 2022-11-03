///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletTemplate.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 39
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// Event documentation should end with an array that provides descriptive names for event
    /// parameters. [something, who]
    /// </summary>
        SomethingStored,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 39
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}
