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
namespace FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 45
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
    /// Generated from meta with Type Id 45
    /// </summary>
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventCreated, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventDestroyed, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventUpdated, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventIssued, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventAttributeCreated, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventAttributeRemoved, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.EventBurned, Tuple<FinalBiome.Api.Types.Primitive.U32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
