///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Types;
namespace FinalBiome.Api.Types.PalletMechanics.Pallet
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
    public class Call : Enum<InnerCall, FinalBiome.Api.Types.PalletMechanics.Pallet.CallExecBuyNfa, FinalBiome.Api.Types.PalletMechanics.Pallet.CallExecBet, FinalBiome.Api.Types.PalletMechanics.Pallet.CallUpgrade>
    {
        public override string TypeName() => "Call";
    }
}
