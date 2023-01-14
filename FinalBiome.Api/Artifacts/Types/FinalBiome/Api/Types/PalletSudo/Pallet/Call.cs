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
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 136
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB write (event).<br/>
    /// - Weight of derivative `call` execution + 10,000.<br/>
    /// # &lt;/weight&gt;<br/>
    /// </summary>
        sudo = 0,
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
    /// This function does not check the weight of the call, and instead allows the<br/>
    /// Sudo user to specify the weight of the call.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - The weight of this call is defined by the caller.<br/>
    /// # &lt;/weight&gt;<br/>
    /// </summary>
        sudo_unchecked_weight = 1,
    /// <summary>
    /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo<br/>
    /// key.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB change.<br/>
    /// # &lt;/weight&gt;<br/>
    /// </summary>
        set_key = 2,
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Signed` origin from<br/>
    /// a given account.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # &lt;weight&gt;<br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB write (event).<br/>
    /// - Weight of derivative `call` execution + 10,000.<br/>
    /// # &lt;/weight&gt;<br/>
    /// </summary>
        sudo_as = 3,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 136
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletSudo.Pallet.CallSudo, FinalBiome.Api.Types.PalletSudo.Pallet.CallSudoUncheckedWeight, FinalBiome.Api.Types.PalletSudo.Pallet.CallSetKey, FinalBiome.Api.Types.PalletSudo.Pallet.CallSudoAs>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
