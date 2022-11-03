///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletSudo.Pallet
{
    /// <summary>
    /// Error for the Sudo pallet
    ///
    ///
    /// Generated from meta with Type Id 167
    /// </summary>
    public enum InnerError
    {
    /// <summary>
    /// Sender must be the Sudo account
    /// </summary>
        RequireSudo,
    }
    /// <summary>
    /// Error for the Sudo pallet
    ///
    ///
    /// Generated from meta with Type Id 167
    /// </summary>
    public class Error : BaseEnumExt<InnerError, BaseVoid>
    {
        public override string TypeName() => "Error";
    }
}
