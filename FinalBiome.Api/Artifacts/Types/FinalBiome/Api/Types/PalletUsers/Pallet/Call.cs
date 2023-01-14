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
namespace FinalBiome.Api.Types.PalletUsers.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 139
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// Authenticates the current registrar key and sets the given AccountId (`new`) as the new<br/>
    /// registrar key.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - One DB read.<br/>
    /// - One DB change.<br/>
    /// # &lt;/weight&gt;<br/>
    /// </summary>
        set_registrar_key = 0,
    /// <summary>
    /// Register a new account.<br/>
    /// <para></para>
    /// User can register only once.<br/>
    /// </summary>
        sign_up = 1,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 139
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletUsers.Pallet.CallSetRegistrarKey, FinalBiome.Api.Types.PalletUsers.Pallet.CallSignUp>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
