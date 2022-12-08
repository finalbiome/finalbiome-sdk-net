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
namespace FinalBiome.Api.Types.PalletBalances
{
    /// <summary>
    /// Generated from meta with Type Id 121
    /// </summary>
    public enum InnerReasons : byte
    {
        Fee = 0,
        Misc = 1,
        All = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 121
    /// </summary>
    public class Reasons : Enum<InnerReasons, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Reasons";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
