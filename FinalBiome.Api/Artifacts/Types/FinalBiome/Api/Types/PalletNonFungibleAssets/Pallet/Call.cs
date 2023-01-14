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
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 154
    /// </summary>
    public enum InnerCall : byte
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
        create = 0,
    /// <summary>
    /// Destroy a non fungible asset class.<br/>
    /// <para></para>
    /// The origin must be Signed and must be a member of the organization<br/>
    /// </summary>
        destroy = 1,
    /// <summary>
    /// Creates an attribute for the non fungible asset class.<br/>
    /// The origin must be Signed, be a member of the organization<br/>
    /// and that organization must be a owner of the asset class.<br/>
    /// </summary>
        create_attribute = 2,
    /// <summary>
    /// Removes an attribute for the non fungible asset class.<br/>
    /// The origin must be Signed, be a member of the organization<br/>
    /// and that organization must be a owner of the asset class.<br/>
    /// </summary>
        remove_attribute = 3,
        set_characteristic = 4,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 154
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.CallCreate, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.CallDestroy, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.CallCreateAttribute, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.CallRemoveAttribute, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.CallSetCharacteristic>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
