///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSupport.Errors
{
    /// <summary>
    /// Generated from meta with Type Id 190
    /// </summary>
    public enum InnerCommonError : byte
    {
        WrongCharacteristic = 0,
        WrongBettor = 1,
        WrongPurchased = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 190
    /// </summary>
    public class CommonError : Enum<InnerCommonError, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "CommonError";
    }
}
