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
namespace FinalBiome.Api.Types.PalletOrganizationIdentity.Types
{
    /// <summary>
    /// Generated from meta with Type Id 134
    /// </summary>
    public enum InnerAirDropAsset : byte
    {
        Fa = 0,
        Nfa = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 134
    /// </summary>
    public class AirDropAsset : Enum<InnerAirDropAsset, Tuple<FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Api.Types.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, Tuple<FinalBiome.Api.Types.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Api.Types.PalletSupport.BoundedVecAttribute>>
    {
        public override string TypeName() => "AirDropAsset";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
