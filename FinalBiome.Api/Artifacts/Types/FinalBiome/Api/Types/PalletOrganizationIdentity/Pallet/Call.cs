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
namespace FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet
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
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.CallCreateOrganization, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.CallAddMember, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.CallRemoveMember, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.CallSetOnboardingAssets, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.CallOnboarding>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
