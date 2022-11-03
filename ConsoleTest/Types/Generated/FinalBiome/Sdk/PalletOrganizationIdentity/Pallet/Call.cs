///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletOrganizationIdentity.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 131
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Create an organization.
    /// Will return an OrganizationExists error if the organization has already
    /// been created. Will emit a CreatedOrganization event on success.
    /// 
    /// The dispatch origin for this call must be Signed.
    /// </summary>
        create_organization,
    /// <summary>
    /// Add member to an organization.
    /// 
    /// # Events
    /// * `MemberAdded`
    /// # Errors
    /// * `NotOrganization` if origin not an organization
    /// * `MembershipLimitReached` if members limit exceeded
    /// * `InvalidMember` if member is organization
    /// * `AlreadyMember` if member already added
    /// </summary>
        add_member,
    /// <summary>
    /// Removes a member from organization.
    /// 
    /// # Events
    /// * `MemberRemoved`
    /// 
    /// # Errors
    /// * `NotOrganization` if origin not an organization
    /// * `NotMember` if a member doesn't exist
    /// * ``
    /// </summary>
        remove_member,
    /// <summary>
    /// Set assets which will be airdroped at game onboarding
    /// </summary>
        set_onboarding_assets,
    /// <summary>
    /// Onboirding to game
    /// </summary>
        onboarding,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 131
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.VecU8, FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.Model.Types.Base.OptionBoundedVecAirDropAsset>, FinalBiome.Sdk.SpCore.Crypto.AccountId32>
    {
        public override string TypeName() => "Call";
    }
}
