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
    /// Generated from meta with Type Id 129
    /// </summary>
    public enum InnerCall
    {
        System,
        Timestamp,
        Grandpa,
        Balances,
        Sudo,
        TemplateModule,
        OrganizationIdentity,
        FungibleAssets,
        NonFungibleAssets,
        Mechanics,
    }
    /// <summary>
    /// Generated from meta with Type Id 129
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.FrameSystem.Pallet.Call, FinalBiome.Sdk.PalletTimestamp.Pallet.Call, FinalBiome.Sdk.PalletGrandpa.Pallet.Call, FinalBiome.Sdk.PalletBalances.Pallet.Call, FinalBiome.Sdk.PalletSudo.Pallet.Call, FinalBiome.Sdk.PalletTemplate.Pallet.Call, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.Call, FinalBiome.Sdk.PalletFungibleAssets.Pallet.Call, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.Call, FinalBiome.Sdk.PalletMechanics.Pallet.Call>
    {
        public override string TypeName() => "Call";
    }
}
