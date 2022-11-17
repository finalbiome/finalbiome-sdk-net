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
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.FrameSystem.Pallet.Call, BaseVoid, FinalBiome.Api.Types.PalletTimestamp.Pallet.Call, BaseVoid, FinalBiome.Api.Types.PalletGrandpa.Pallet.Call, FinalBiome.Api.Types.PalletBalances.Pallet.Call, BaseVoid, FinalBiome.Api.Types.PalletSudo.Pallet.Call, FinalBiome.Api.Types.PalletTemplate.Pallet.Call, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.Call, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.Call, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.Call, FinalBiome.Api.Types.PalletMechanics.Pallet.Call>
    {
        public override string TypeName() => "Call";
    }
}
