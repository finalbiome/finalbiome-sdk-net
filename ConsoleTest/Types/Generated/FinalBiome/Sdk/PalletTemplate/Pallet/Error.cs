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
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 168
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Error names should be descriptive.
    /// </summary>
        NoneValue,
    /// <summary>
    /// Errors should have helpful documentation associated with them.
    /// </summary>
        StorageOverflow,
    }
    /// <summary>
    ///  Custom [dispatch errors](https://docs.substrate.io/main-docs/build/events-errors/) of this pallet. 
    ///
    ///
    /// Generated from meta with Type Id 168
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
