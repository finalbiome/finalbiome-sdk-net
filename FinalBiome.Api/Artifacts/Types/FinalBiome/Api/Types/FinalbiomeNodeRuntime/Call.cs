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
namespace FinalBiome.Api.Types.FinalbiomeNodeRuntime
{
    /// <summary>
    /// Generated from meta with Type Id 137
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
        Users = 9,
        OrganizationIdentity = 10,
        FungibleAssets = 11,
        NonFungibleAssets = 12,
        Mechanics = 13,
    }
    /// <summary>
    /// Generated from meta with Type Id 137
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.FrameSystem.Pallet.Call, BaseVoid, FinalBiome.Api.Types.PalletTimestamp.Pallet.Call, BaseVoid, FinalBiome.Api.Types.PalletGrandpa.Pallet.Call, FinalBiome.Api.Types.PalletBalances.Pallet.Call, BaseVoid, FinalBiome.Api.Types.PalletSudo.Pallet.Call, FinalBiome.Api.Types.PalletTemplate.Pallet.Call, FinalBiome.Api.Types.PalletUsers.Pallet.Call, FinalBiome.Api.Types.PalletOrganizationIdentity.Pallet.Call, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.Call, FinalBiome.Api.Types.PalletNonFungibleAssets.Pallet.Call, FinalBiome.Api.Types.PalletMechanics.Pallet.Call>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
