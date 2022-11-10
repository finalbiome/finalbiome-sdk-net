///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.FinalbiomeNodeRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 17
    /// </summary>
    public enum InnerEvent : byte
    {
        System = 0,
        Unsupported_1 = 1,
        Unsupported_2 = 2,
        Unsupported_3 = 3,
        Grandpa = 4,
        Balances = 5,
        TransactionPayment = 6,
        Sudo = 7,
        TemplateModule = 8,
        OrganizationIdentity = 9,
        FungibleAssets = 10,
        NonFungibleAssets = 11,
        Mechanics = 12,
    }
    /// <summary>
    /// Generated from meta with Type Id 17
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.FrameSystem.Pallet.Event, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Sdk.PalletGrandpa.Pallet.Event, FinalBiome.Sdk.PalletBalances.Pallet.Event, FinalBiome.Sdk.PalletTransactionPayment.Pallet.Event, FinalBiome.Sdk.PalletSudo.Pallet.Event, FinalBiome.Sdk.PalletTemplate.Pallet.Event, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.Event, FinalBiome.Sdk.PalletFungibleAssets.Pallet.Event, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.Event, FinalBiome.Sdk.PalletMechanics.Pallet.Event>
    {
        public override string TypeName() => "Event";
    }
}
