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
    public enum InnerEvent
    {
        System,
        Grandpa,
        Balances,
        TransactionPayment,
        Sudo,
        TemplateModule,
        OrganizationIdentity,
        FungibleAssets,
        NonFungibleAssets,
        Mechanics,
    }
    /// <summary>
    /// Generated from meta with Type Id 17
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.FrameSystem.Pallet.Event, FinalBiome.Sdk.PalletGrandpa.Pallet.Event, FinalBiome.Sdk.PalletBalances.Pallet.Event, FinalBiome.Sdk.PalletTransactionPayment.Pallet.Event, FinalBiome.Sdk.PalletSudo.Pallet.Event, FinalBiome.Sdk.PalletTemplate.Pallet.Event, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.Event, FinalBiome.Sdk.PalletFungibleAssets.Pallet.Event, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.Event, FinalBiome.Sdk.PalletMechanics.Pallet.Event>
    {
        public override string TypeName() => "Event";
    }
}
