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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 172
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Error names should be descriptive.<br/>
    /// </summary>
        NoneValue,
    /// <summary>
    /// Errors should have helpful documentation associated with them.<br/>
    /// </summary>
        StorageOverflow,
    /// <summary>
    /// Cannot create the organization because it already exists.<br/>
    /// </summary>
        OrganizationExists,
    /// <summary>
    /// Organization name is too long.<br/>
    /// </summary>
        OrganizationNameTooLong,
    /// <summary>
    /// Account is not an organization<br/>
    /// </summary>
        NotOrganization,
    /// <summary>
    /// Cannot add a user to an organization to which they already belong.<br/>
    /// </summary>
        AlreadyMember,
    /// <summary>
    /// Cannot add another member because the limit is already reached.<br/>
    /// </summary>
        MembershipLimitReached,
    /// <summary>
    /// Cannot add organization as an organization's member.<br/>
    /// </summary>
        InvalidMember,
    /// <summary>
    /// Member not exits.<br/>
    /// </summary>
        NotMember,
    /// <summary>
    /// Account has already been onboarded.<br/>
    /// </summary>
        AlreadyOnboarded,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 172
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
