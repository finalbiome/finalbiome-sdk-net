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
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 128
    /// </summary>
    public enum InnerCall
    {
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.
    /// 
    /// The dispatch origin for this call must be _Signed_.
    /// 
    /// # <weight>
    /// - O(1).
    /// - Limited storage reads.
    /// - One DB write (event).
    /// - Weight of derivative `call` execution + 10,000.
    /// # </weight>
    /// </summary>
        sudo,
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Root` origin.
    /// This function does not check the weight of the call, and instead allows the
    /// Sudo user to specify the weight of the call.
    /// 
    /// The dispatch origin for this call must be _Signed_.
    /// 
    /// # <weight>
    /// - O(1).
    /// - The weight of this call is defined by the caller.
    /// # </weight>
    /// </summary>
        sudo_unchecked_weight,
    /// <summary>
    /// Authenticates the current sudo key and sets the given AccountId (`new`) as the new sudo
    /// key.
    /// 
    /// The dispatch origin for this call must be _Signed_.
    /// 
    /// # <weight>
    /// - O(1).
    /// - Limited storage reads.
    /// - One DB change.
    /// # </weight>
    /// </summary>
        set_key,
    /// <summary>
    /// Authenticates the sudo key and dispatches a function call with `Signed` origin from
    /// a given account.
    /// 
    /// The dispatch origin for this call must be _Signed_.
    /// 
    /// # <weight>
    /// - O(1).
    /// - Limited storage reads.
    /// - One DB write (event).
    /// - Weight of derivative `call` execution + 10,000.
    /// # </weight>
    /// </summary>
        sudo_as,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.
    ///
    ///
    /// Generated from meta with Type Id 128
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.FinalbiomeNodeRuntime.Call, BaseTuple<FinalBiome.Sdk.FinalbiomeNodeRuntime.Call, Ajuna.NetApi.Model.Types.Primitive.U64>, FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, BaseTuple<FinalBiome.Sdk.SpRuntime.Multiaddress.MultiAddress, FinalBiome.Sdk.FinalbiomeNodeRuntime.Call>>
    {
        public override string TypeName() => "Call";
    }
}
