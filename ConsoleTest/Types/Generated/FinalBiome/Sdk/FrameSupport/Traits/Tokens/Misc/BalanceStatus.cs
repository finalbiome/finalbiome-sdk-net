///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.FrameSupport.Traits.Tokens.Misc
{
    /// <summary>
    /// Generated from meta with Type Id 33
    /// </summary>
    public enum InnerBalanceStatus : byte
    {
        Free = 0,
        Reserved = 1,
    }
    /// <summary>
    /// Generated from meta with Type Id 33
    /// </summary>
    public class BalanceStatus : BaseEnumExt<InnerBalanceStatus, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "BalanceStatus";
    }
}
