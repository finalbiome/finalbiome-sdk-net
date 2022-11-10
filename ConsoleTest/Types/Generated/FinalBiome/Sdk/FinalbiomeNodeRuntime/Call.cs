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
    public enum InnerCall : byte
    {
        System = 0,
        Unsupported_1 = 1,
        Timestamp = 2,
        Unsupported_3 = 3,
        Grandpa = 4,
        Balances = 5,
        Unsupported_6 = 6,
        Sudo = 7,
        TemplateModule = 8,
        OrganizationIdentity = 9,
        FungibleAssets = 10,
        NonFungibleAssets = 11,
        Mechanics = 12,
    }
    /// <summary>
    /// Generated from meta with Type Id 129
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.FrameSystem.Pallet.Call, BaseVoid, FinalBiome.Sdk.PalletTimestamp.Pallet.Call, BaseVoid, FinalBiome.Sdk.PalletGrandpa.Pallet.Call, FinalBiome.Sdk.PalletBalances.Pallet.Call, BaseVoid, FinalBiome.Sdk.PalletSudo.Pallet.Call, FinalBiome.Sdk.PalletTemplate.Pallet.Call, FinalBiome.Sdk.PalletOrganizationIdentity.Pallet.Call, FinalBiome.Sdk.PalletFungibleAssets.Pallet.Call, FinalBiome.Sdk.PalletNonFungibleAssets.Pallet.Call, FinalBiome.Sdk.PalletMechanics.Pallet.Call>
    {
        public override string TypeName() => "Call";
    }
}
