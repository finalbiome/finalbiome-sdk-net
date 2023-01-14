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
namespace FinalBiome.Api.Types.PalletFungibleAssets.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 148
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// Issue a new fungible asset from.<br/>
    /// <para></para>
    /// This new asset has owner as orgaization.<br/>
    /// <para></para>
    /// The origin must be Signed.<br/>
    /// <para></para>
    /// <para></para>
    /// Parameters:<br/>
    /// - `organization_id`: The identifier of the organization. Origin must be member of it.<br/>
    /// <para></para>
    /// Emits `Created` event when successful.<br/>
    /// </summary>
        create = 0,
    /// <summary>
    /// Destroy a fungible asset.<br/>
    /// <para></para>
    /// The origin must be Signed and must be a member of the organization<br/>
    /// </summary>
        destroy = 1,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 148
    /// </summary>
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.CallCreate, FinalBiome.Api.Types.PalletFungibleAssets.Pallet.CallDestroy>
    {
        public override string TypeName() => "Call";
    }
}

#pragma warning restore IDE0090
#pragma warning restore CA1822
#pragma warning restore IDE0028
#pragma warning restore IDE0052
