///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletSudo.Pallet
{
    /// <summary>
    /// Error for the Sudo pallet<br/>
    ///
    ///
    /// Generated from meta with Type Id 167
    /// </summary>
    public enum InnerError : byte
    {
    /// <summary>
    /// Sender must be the Sudo account<br/>
    /// </summary>
        RequireSudo = 0,
    }
    /// <summary>
    /// Error for the Sudo pallet<br/>
    ///
    ///
    /// Generated from meta with Type Id 167
    /// </summary>
    public class Error : Enum<InnerError, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
