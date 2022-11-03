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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 172
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Error names should be descriptive.
    /// </summary>
        NoneValue,
    /// <summary>
    /// Errors should have helpful documentation associated with them.
    /// </summary>
        StorageOverflow,
    /// <summary>
    /// Cannot create the organization because it already exists.
    /// </summary>
        OrganizationExists,
    /// <summary>
    /// Organization name is too long.
    /// </summary>
        OrganizationNameTooLong,
    /// <summary>
    /// Account is not an organization
    /// </summary>
        NotOrganization,
    /// <summary>
    /// Cannot add a user to an organization to which they already belong.
    /// </summary>
        AlreadyMember,
    /// <summary>
    /// Cannot add another member because the limit is already reached.
    /// </summary>
        MembershipLimitReached,
    /// <summary>
    /// Cannot add organization as an organization's member.
    /// </summary>
        InvalidMember,
    /// <summary>
    /// Member not exits.
    /// </summary>
        NotMember,
    /// <summary>
    /// Account has already been onboarded.
    /// </summary>
        AlreadyOnboarded,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 172
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
