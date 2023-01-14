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
namespace FinalBiome.Api.Types.PalletSudo.Pallet
{
    /// <summary>
    /// Error for the Sudo pallet<br/>
    ///
    ///
    /// Generated from meta with Type Id 176
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
    /// Generated from meta with Type Id 176
    /// </summary>
    public class Error : Enum<InnerError, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
