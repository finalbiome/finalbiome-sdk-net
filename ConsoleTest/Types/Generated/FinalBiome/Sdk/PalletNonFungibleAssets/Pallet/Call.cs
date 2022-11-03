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
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 145
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Issue a new non fungible class.
    /// 
    /// This new class has owner as orgaization.
    /// 
    /// The origin must be Signed.
    /// 
    /// Parameters:
    /// - `organization_id`: The identifier of the organization. Origin must be member of it.
    /// 
    /// Emits `Created` event when successful.
    /// </summary>
        create,
    /// <summary>
    /// Destroy a non fungible asset class.
    /// 
    /// The origin must be Signed and must be a member of the organization
    /// </summary>
        destroy,
    /// <summary>
    /// Creates an attribute for the non fungible asset class.
    /// The origin must be Signed, be a member of the organization
    /// and that organization must be a owner of the asset class.
    /// </summary>
        create_attribute,
    /// <summary>
    /// Removes an attribute for the non fungible asset class.
    /// The origin must be Signed, be a member of the organization
    /// and that organization must be a owner of the asset class.
    /// </summary>
        remove_attribute,
        set_characteristic,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 145
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.VecU8>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId, FinalBiome.Sdk.PalletSupport.Attribute>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId, FinalBiome.Sdk.BoundedVecU8>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.CompactNonFungibleClassId, FinalBiome.Sdk.PalletSupport.Characteristics.Characteristic>>
    {
        public override string TypeName() => "Call";
    }
}
