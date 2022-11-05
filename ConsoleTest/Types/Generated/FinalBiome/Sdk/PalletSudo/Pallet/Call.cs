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
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 128
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB write (event).<br/>
    /// - Weight of derivative `call` execution + 10,000.<br/>
    /// # </weight><br/>
    /// </summary>
        sudo,
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.<br/>
    /// This function does not check the weight of the call, and instead allows the<br/>
    /// Sudo user to specify the weight of the call.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - O(1).<br/>
    /// - The weight of this call is defined by the caller.<br/>
    /// # </weight><br/>
    /// </summary>
        sudo_unchecked_weight,
    /// <summary>
    /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo<br/>
    /// key.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB change.<br/>
    /// # </weight><br/>
    /// </summary>
        set_key,
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Signed` origin from<br/>
    /// a given account.<br/>
    /// <para></para>
    /// The dispatch origin for this call must be _Signed_.<br/>
    /// <para></para>
    /// # <weight><br/>
    /// - O(1).<br/>
    /// - Limited storage reads.<br/>
    /// - One DB write (event).<br/>
    /// - Weight of derivative `call` execution + 10,000.<br/>
    /// # </weight><br/>
    /// </summary>
        sudo_as,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 128
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.FinalbiomeNodeRuntime.Call, BaseTuple<FinalBiome.Sdk.FinalbiomeNodeRuntime.Call, Ajuna.NetApi.Model.Types.Primitive.U64>, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.FinalbiomeNodeRuntime.Call>>
    {
        public override string TypeName() => "Call";
    }
}
