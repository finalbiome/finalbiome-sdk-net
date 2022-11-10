///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Types
{
    /// <summary>
    /// Generated from meta with Type Id 54
    /// </summary>
    public enum InnerEventMechanicResultData : byte
    {
        BuyNfa = 0,
        Bet = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 54
    /// </summary>
    public class EventMechanicResultData : BaseEnumExt<InnerEventMechanicResultData, FinalBiome.Sdk.PalletSupport.Types.NonFungibleAssetId.NonFungibleAssetId, FinalBiome.Sdk.PalletMechanics.Types.EventMechanicResultDataBet>
    {
        public override string TypeName() => "EventMechanicResultData";
    }
}
