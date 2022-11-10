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
    public enum InnerError : byte
    {
    /// <summary>
    /// Error names should be descriptive.<br/>
    /// </summary>
        NoneValue = 0,
    /// <summary>
    /// Errors should have helpful documentation associated with them.<br/>
    /// </summary>
        StorageOverflow = 1,
    /// <summary>
    /// Cannot create the organization because it already exists.<br/>
    /// </summary>
        OrganizationExists = 2,
    /// <summary>
    /// Organization name is too long.<br/>
    /// </summary>
        OrganizationNameTooLong = 3,
    /// <summary>
    /// Account is not an organization<br/>
    /// </summary>
        NotOrganization = 4,
    /// <summary>
    /// Cannot add a user to an organization to which they already belong.<br/>
    /// </summary>
        AlreadyMember = 5,
    /// <summary>
    /// Cannot add another member because the limit is already reached.<br/>
    /// </summary>
        MembershipLimitReached = 6,
    /// <summary>
    /// Cannot add organization as an organization's member.<br/>
    /// </summary>
        InvalidMember = 7,
    /// <summary>
    /// Member not exits.<br/>
    /// </summary>
        NotMember = 8,
    /// <summary>
    /// Account has already been onboarded.<br/>
    /// </summary>
        AlreadyOnboarded = 9,
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
