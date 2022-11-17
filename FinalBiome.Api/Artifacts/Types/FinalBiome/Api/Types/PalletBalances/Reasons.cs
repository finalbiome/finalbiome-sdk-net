///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletBalances
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
    public class Reasons : Enum<InnerReasons, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Reasons";
    }
}
