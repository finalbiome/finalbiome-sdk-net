///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport.Characteristics
{
    /// <summary>
    /// Generated from meta with Type Id 147
    /// </summary>
    public enum InnerCharacteristic : byte
    {
        Bettor = 0,
        Purchased = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 147
    /// </summary>
    public class Characteristic : BaseEnumExt<InnerCharacteristic, FinalBiome.Sdk.Model.Types.Base.OptionBettor, FinalBiome.Sdk.Model.Types.Base.OptionPurchased>
    {
        public override string TypeName() => "Characteristic";
    }
}
