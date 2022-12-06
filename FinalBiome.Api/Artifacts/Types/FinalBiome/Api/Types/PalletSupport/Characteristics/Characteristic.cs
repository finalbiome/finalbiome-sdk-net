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

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
