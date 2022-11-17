///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport.Characteristics
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
    public class Characteristic : Enum<InnerCharacteristic, FinalBiome.Api.Types.OptionBettor, FinalBiome.Api.Types.OptionPurchased>
    {
        public override string TypeName() => "Characteristic";
    }
}
