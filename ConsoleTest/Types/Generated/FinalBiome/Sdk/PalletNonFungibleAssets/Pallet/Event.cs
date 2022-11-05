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
    public enum InnerEvent
    {
    /// <summary>
    /// An asset class has been created.<br/>
    /// </summary>
        Created,
    /// <summary>
    /// An asset class has been destroyed.<br/>
    /// </summary>
        Destroyed,
    /// <summary>
    /// An asset class has been updated.<br/>
    /// </summary>
        Updated,
    /// <summary>
    /// An asset `instance` has been issued.<br/>
    /// </summary>
        Issued,
    /// <summary>
    /// New attribute metadata has been set for the asset class.<br/>
    /// </summary>
        AttributeCreated,
    /// <summary>
    /// Attribute metadata has been removed for the asset class.<br/>
    /// </summary>
        AttributeRemoved,
    /// <summary>
    /// An asset `instance` was destroyed.<br/>
    /// </summary>
        Burned,
    /// <summary>
    /// Event documentation should end with an array that provides descriptive names for event<br/>
    /// parameters. [something, who]<br/>
    /// </summary>
        SomethingStored,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 44
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.BoundedVecU8, FinalBiome.Sdk.PalletSupport.AttributeValue>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.BoundedVecU8>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}
