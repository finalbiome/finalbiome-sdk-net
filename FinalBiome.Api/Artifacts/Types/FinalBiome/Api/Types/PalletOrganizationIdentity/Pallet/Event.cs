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
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 40
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// Event documentation should end with an array that provides descriptive names for event<br/>
    /// parameters. [something, who]<br/>
    /// </summary>
        SomethingStored = 0,
    /// <summary>
    /// An organization has been created. [organization_name, who]<br/>
    /// </summary>
        CreatedOrganization = 1,
    /// <summary>
    /// An asset class has been updated.<br/>
    /// </summary>
        UpdatedOrganization = 2,
    /// <summary>
    /// An member was added to an organization. [organization, member]<br/>
    /// </summary>
        MemberAdded = 3,
    /// <summary>
    /// An member was removed from organization. [organization, member]<br/>
    /// </summary>
        MemberRemoved = 4,
    /// <summary>
    /// Assets for the game has been airdropped.<br/>
    /// </summary>
        Onboard = 5,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 40
    /// </summary>
    public class Event : Enum<InnerEvent, Tuple<FinalBiome.Api.Types.Primitive.U32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32>, Tuple<FinalBiome.Api.Types.VecU8, FinalBiome.Api.Types.SpCore.Crypto.AccountId32>, FinalBiome.Api.Types.SpCore.Crypto.AccountId32, Tuple<FinalBiome.Api.Types.SpCore.Crypto.AccountId32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32>, Tuple<FinalBiome.Api.Types.SpCore.Crypto.AccountId32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32>, Tuple<FinalBiome.Api.Types.SpCore.Crypto.AccountId32, FinalBiome.Api.Types.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
