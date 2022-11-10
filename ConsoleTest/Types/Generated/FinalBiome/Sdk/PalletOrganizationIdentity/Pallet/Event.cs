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
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.VecU8, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, FinalBiome.Sdk.SpCore.Crypto.AccountId32, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}
