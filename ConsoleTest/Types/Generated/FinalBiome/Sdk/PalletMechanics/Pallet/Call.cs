///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletMechanics.Pallet
{
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 163
    /// </summary>
    public enum InnerCall : byte
    {
    /// <summary>
    /// Execute mechanic `Buy NFA`<br/>
    /// </summary>
        exec_buy_nfa = 0,
    /// <summary>
    /// Execute mechanic `Bet`<br/>
    /// </summary>
        exec_bet = 1,
    /// <summary>
    /// Upgrade mechanic<br/>
    /// </summary>
        upgrade = 2,
    }
    /// <summary>
    /// Contains one variant per dispatchable that can be called by an extrinsic.<br/>
    ///
    ///
    /// Generated from meta with Type Id 163
    /// </summary>
    public class Call : BaseEnumExt<InnerCall, FinalBiome.Sdk.PalletMechanics.Pallet.CallExecBuyNfa, FinalBiome.Sdk.PalletMechanics.Pallet.CallExecBet, FinalBiome.Sdk.PalletMechanics.Pallet.CallUpgrade>
    {
        public override string TypeName() => "Call";
    }
}
