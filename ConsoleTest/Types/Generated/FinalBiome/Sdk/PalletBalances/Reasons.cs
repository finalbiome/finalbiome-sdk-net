///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletBalances
{
    /// <summary>
    /// Generated from meta with Type Id 114
    /// </summary>
    public enum InnerReasons : byte
    {
        Fee = 0,
        Misc = 1,
        All = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 114
    /// </summary>
    public class Reasons : BaseEnumExt<InnerReasons, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Reasons";
    }
}
