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
namespace FinalBiome.Api.Types.PalletSupport.Errors
{
    /// <summary>
    /// Generated from meta with Type Id 202
    /// </summary>
    public enum InnerCommonError : byte
    {
        WrongCharacteristic = 0,
        WrongBettor = 1,
        WrongPurchased = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 202
    /// </summary>
    public class CommonError : Enum<InnerCommonError, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "CommonError";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
