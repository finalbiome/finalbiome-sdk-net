///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletTemplate.Pallet
{
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 168
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// Error names should be descriptive.<br/>
    /// </summary>
        NoneValue = 0,
    /// <summary>
    /// Errors should have helpful documentation associated with them.<br/>
    /// </summary>
        StorageOverflow = 1,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 168
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
