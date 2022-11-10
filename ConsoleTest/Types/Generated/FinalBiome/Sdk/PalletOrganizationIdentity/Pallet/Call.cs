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
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 131
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// Create an organization.<br/>
    /// Will return an OrganizationExists error if the organization has already<br/>
    /// been created. Will emit a CreatedOrganization event on success.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be Signed.<br/>
    /// </summary>
        create_organization = 0,
    /// <summary>
    /// Add member to an organization.<br/>
    /// <para></para>
    /// # Events<br/>
    /// * `MemberAdded`<br/>
    /// # Errors<br/>
    /// * `NotOrganization` if origin not an organization<br/>
    /// * `MembershipLimitReached` if members limit exceeded<br/>
    /// * `InvalidMember` if member is organization<br/>
    /// * `AlreadyMember` if member already added<br/>
    /// </summary>
        add_member = 1,
    /// <summary>
    /// Removes a member from organization.<br/>
    /// <para></para>
    /// # Events<br/>
    /// * `MemberRemoved`<br/>
    /// <para></para>
    /// # Errors<br/>
    /// * `NotOrganization` if origin not an organization<br/>
    /// * `NotMember` if a member doesn't exist<br/>
    /// * ``<br/>
    /// </summary>
        remove_member = 2,
    /// <summary>
    /// Set assets which will be airdroped at game onboarding<br/>
    /// </summary>
        set_onboarding_assets = 3,
    /// <summary>
    /// Onboirding to game<br/>
    /// </summary>
        onboarding = 4,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 131
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.CallCreateOrganization, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.CallAddMember, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.CallRemoveMember, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.CallSetOnboardingAssets, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.CallOnboarding>
    {
        public override string TypeName() => "Call";
    }
}
