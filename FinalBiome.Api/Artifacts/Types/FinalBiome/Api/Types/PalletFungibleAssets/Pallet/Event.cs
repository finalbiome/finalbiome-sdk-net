///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletFungibleAssets.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 41
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// The asset has been created.<br/>
    /// </summary>
        Created = 0,
    /// <summary>
    /// Some assets were issued.<br/>
    /// </summary>
        Issued = 1,
    /// <summary>
    /// Some assets were destroyed.<br/>
    /// </summary>
        Burned = 2,
    /// <summary>
    /// Event documentation should end with an array that provides descriptive names for event<br/>
    /// parameters. [something, who]<br/>
    /// </summary>
        SomethingStored = 3,
    /// <summary>
    /// An asset class was destroyed.<br/>
    /// </summary>
        Destroyed = 4,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 41
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.EventCreated, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.EventIssued, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.EventBurned, Tuple<FinalBiome.Api.Types.Primitive.U32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32>, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.EventDestroyed>
    {
        public override string TypeName() => "Event";
    }
}
