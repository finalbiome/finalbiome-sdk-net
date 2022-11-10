///
/// This file is generated automatically
/// DO NOT CHANGE THE CONTENT OF THE FILE!
///
using System.Numerics;
using Ajuna.NetApi.Model.Types.Primitive;
using Ajuna.NetApi.Model.Types.Base;
namespace FinalBiome.Sdk.PalletTransactionPayment.Pallet
{
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 34
    /// </summary>
    public enum InnerEvent : byte
    {
    /// <summary>
    /// A transaction fee `actual_fee`, of which `tip` was added to the minimum inclusion fee,<br/>
    /// has been paid by `who`.<br/>
    /// </summary>
        TransactionFeePaid = 0,
    }
    /// <summary>
    ///  The [event](https://docs.substrate.io/main-docs/build/events-errors/) emitted by this pallet. <br/>
    ///
    ///
    /// Generated from meta with Type Id 34
    /// </summary>
    public class Event : BaseEnumExt<InnerEvent, FinalBiome.Sdk.PalletTransactionPayment.Pallet.EventTransactionFeePaid>
    {
        public override string TypeName() => "Event";
    }
}
