///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletOrganizationIdentity.Types
{
    /// <summary>
    /// Generated from meta with Type Id 134
    /// </summary>
    public enum InnerAirDropAsset
    {
        Fa,
        Nfa,
    }
    /// <summary>
    /// Generated from meta with Type Id 134
    /// </summary>
    public class AirDropAsset : BaseEnumExt<InnerAirDropAsset, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.FungibleAssetId.FungibleAssetId, FinalBiome.Sdk.PalletSupport.Types.FungibleAssetBalance.FungibleAssetBalance>, BaseTuple<FinalBiome.Sdk.PalletSupport.Types.NonFungibleClassId.NonFungibleClassId, FinalBiome.Sdk.PalletSupport.BoundedVecAttribute>>
    {
        public override string TypeName() => "AirDropAsset";
    }
}
