///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.FinalbiomeNodeRuntime
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
    public class Event : Enum<InnerEvent, FinalBiome.Api.Types.FrameSystem.Pallet.Event, BaseVoid, BaseVoid, BaseVoid, FinalBiome.Api.Types.PalletGrandpa.Pallet.Event, FinalBiome.Api.Types.PalletBalances.Pallet.Event, FinalBiome.Api.Types.PalletTransactionPayment.Pallet.Event, FinalBiome.Api.Types.PalletSudo.Pallet.Event, FinalBiome.Api.Types.PalletTemplate.Pallet.Event, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.Event, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.Event, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.Event, FinalBiome.Api.Types.PalletMechanics.Pallet.Event>
    {
        public override string TypeName() => "Event";
    }
}
