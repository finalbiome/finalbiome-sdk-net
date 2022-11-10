///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSupport.Characteristics.Bettor
{
    /// <summary>
    /// Generated from meta with Type Id 152
    /// </summary>
    public enum InnerOutcomeResult : byte
    {
        Win = 0,
        Lose = 1,
        Draw = 2,
    }
    /// <summary>
    /// Generated from meta with Type Id 152
    /// </summary>
    public class OutcomeResult : BaseEnumExt<InnerOutcomeResult, BaseVoid, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "OutcomeResult";
    }
}
