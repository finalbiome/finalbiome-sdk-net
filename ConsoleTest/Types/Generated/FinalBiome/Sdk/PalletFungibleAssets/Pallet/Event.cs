///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletFungibleAssets.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 41
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// The asset has been created.<br/>
    /// </summary>
        Created,
    /// <summary>
    /// Some assets were issued.<br/>
    /// </summary>
        Issued,
    /// <summary>
    /// Some assets were destroyed.<br/>
    /// </summary>
        Burned,
    /// <summary>
    /// Event documentation should end with an array that provides descriptive names for event<br/>
    /// parameters. [something, who]<br/>
    /// </summary>
        SomethingStored,
    /// <summary>
    /// An asset class was destroyed.<br/>
    /// </summary>
        Destroyed,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 41
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Sdk.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}
