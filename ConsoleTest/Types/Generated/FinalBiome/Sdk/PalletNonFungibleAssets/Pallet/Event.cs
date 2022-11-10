///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 44
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// An asset class has been created.<br/>
    /// </summary>
        Created = 0,
    /// <summary>
    /// An asset class has been destroyed.<br/>
    /// </summary>
        Destroyed = 1,
    /// <summary>
    /// An asset class has been updated.<br/>
    /// </summary>
        Updated = 2,
    /// <summary>
    /// An asset `instance` has been issued.<br/>
    /// </summary>
        Issued = 3,
    /// <summary>
    /// New attribute metadata has been set for the asset class.<br/>
    /// </summary>
        AttributeCreated = 4,
    /// <summary>
    /// Attribute metadata has been removed for the asset class.<br/>
    /// </summary>
        AttributeRemoved = 5,
    /// <summary>
    /// An asset `instance` was destroyed.<br/>
    /// </summary>
        Burned = 6,
    /// <summary>
    /// Event documentation should end with an array that provides descriptive names for event<br/>
    /// parameters. [something, who]<br/>
    /// </summary>
        SomethingStored = 7,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 44
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.EventCreated, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.EventDestroyed, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.EventUpdated, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.EventIssued, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.EventAttributeCreated, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.EventAttributeRemoved, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.EventBurned, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}
