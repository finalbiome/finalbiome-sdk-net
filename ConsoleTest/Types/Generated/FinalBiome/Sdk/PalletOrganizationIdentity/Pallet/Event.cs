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
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 40
    /// </summary>
    public enum InnerEvent
    {
    /// <summary>
    /// Event documentation should end with an array that provides descriptive names for event
    /// parameters. [something, who]
    /// </summary>
        SomethingStored,
    /// <summary>
    /// An organization has been created. [organization_name, who]
    /// </summary>
        CreatedOrganization,
    /// <summary>
    /// An asset class has been updated.
    /// </summary>
        UpdatedOrganization,
    /// <summary>
    /// An member was added to an organization. [organization, member]
    /// </summary>
        MemberAdded,
    /// <summary>
    /// An member was removed from organization. [organization, member]
    /// </summary>
        MemberRemoved,
    /// <summary>
    /// Assets for the game has been airdropped.
    /// </summary>
        Onboard,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 40
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, BaseTuple<Ajuna.NetApi.Model.Types.Primitive.U32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.VecU8, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, FinalBiome.Sdk.SpCore.Crypto.AccountId32, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>, BaseTuple<FinalBiome.Sdk.SpCore.Crypto.AccountId32, FinalBiome.Sdk.SpCore.Crypto.AccountId32>>
    {
        public override string TypeName() => "Event";
    }
}
