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
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 139
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Issue a new fungible asset from.<br/>
    /// <para></para>
    /// This new asset has owner as orgaization.<br/>
    /// <para></para>
    /// The origin must be Signed.<br/>
    /// <para></para>
    /// <para></para>
    /// Parameters:<br/>
    /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
    /// <para></para>
    /// Emits `Created` event when successful.<br/>
    /// </summary>
        create,
    /// <summary>
    /// Destroy a fungible asset.<br/>
    /// <para></para>
    /// The origin must be Signed and must be a member of the organization<br/>
    /// </summary>
        destroy,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 139
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.PalletFungibleAssets.Pallet.CallCreate, FinalBiome.Sdk.PalletFungibleAssets.Pallet.CallDestroy>
    {
        public override string TypeName() => "Call";
    }
}
