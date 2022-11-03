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
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 139
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Issue a new fungible asset from.
    /// 
    /// This new asset has owner as orgaization.
    /// 
    /// The origin must be Signed.
    /// 
    /// 
    /// Parameters:
    /// - `organization_id`: The identifier of the organization. Origin must be member of it.
    /// 
    /// Emits `Created` event when successful.
    /// </summary>
        create,
    /// <summary>
    /// Destroy a fungible asset.
    /// 
    /// The origin must be Signed and must be a member of the organization
    /// </summary>
        destroy,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 139
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.VecU8, FinalBiome.Sdk.Model.Types.Base.OptionTopUppedFA, FinalBiome.Sdk.Model.Types.Base.OptionCupFA, FinalBiome.Sdk.Model.Types.Base.OptionCupFA>, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.CompactFungibleAssetId>>
    {
        public override string TypeName() => "Call";
    }
}
