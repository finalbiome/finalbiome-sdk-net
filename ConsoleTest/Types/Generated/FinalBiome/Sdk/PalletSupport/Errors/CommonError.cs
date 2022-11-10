///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport.Errors
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
    public class CommonError : BaseEnumExt<InnerCommonError, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "CommonError";
    }
}
