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
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 145
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Issue a new non fungible class.<br/>
    /// <para></para>
    /// This new class has owner as orgaization.<br/>
    /// <para></para>
    /// The origin must be Signed.<br/>
    /// <para></para>
    /// Parameters:<br/>
    /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
    /// <para></para>
    /// Emits `Created` event when successful.<br/>
    /// </summary>
        create,
    /// <summary>
    /// Destroy a non fungible asset class.<br/>
    /// <para></para>
    /// The origin must be Signed and must be a member of the organization<br/>
    /// </summary>
        destroy,
    /// <summary>
    /// Creates an attribute for the non fungible asset class.<br/>
    /// The origin must be Signed, be a member of the organization<br/>
    /// and that organization must be a owner of the asset class.<br/>
    /// </summary>
        create_attribute,
    /// <summary>
    /// Removes an attribute for the non fungible asset class.<br/>
    /// The origin must be Signed, be a member of the organization<br/>
    /// and that organization must be a owner of the asset class.<br/>
    /// </summary>
        remove_attribute,
        set_characteristic,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 145
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.CallCreate, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.CallDestroy, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.CallCreateAttribute, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.CallRemoveAttribute, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.CallSetCharacteristic>
    {
        public override string TypeName() => "Call";
    }
}
