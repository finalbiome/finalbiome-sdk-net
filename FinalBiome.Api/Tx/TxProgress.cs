using System.Threading.Tasks;
using FinalBiome.Api.Blocks;
using FinalBiome.Api.Rpc;
using FinalBiome.Api.Rpc.Types;
using FinalBiome.Api.Types;

namespace FinalBiome.Api.Tx;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
/// <summary>
/// This struct represents a subscription to the progress of some transaction.
/// </summary>
public class TxProgress
{
    Subscription<SubstrateTxStatus>? sub;
    byte[] extHash;
    Client client;

    public TxProgress(Subscription<SubstrateTxStatus> sub, Client client, byte[] extHash)
    {
        this.sub = sub;
        this.client = client;
        this.extHash = extHash;
    }

    /// <summary>
    /// Return the hash of the extrinsic.
    /// </summary>
    public byte[] ExtrinsicHash => this.extHash;

    /// <summary>
    /// Return the next transaction status when it's emitted.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async IAsyncEnumerable<TxStatus> NextItem()
    {
        if (sub is not null)
        await foreach (var status in sub.data())
        {
            switch (status.Value)
            {
                case InnerSubstrateTxStatus.Future:
                    var txs0 = new TxStatus();
                    txs0.Init(InnerTxStatus.Future, status.Value2);
                    yield return txs0;
                    break;
                case InnerSubstrateTxStatus.Ready:
                    var txs1 = new TxStatus();
                    txs1.Init(InnerTxStatus.Ready, status.Value2);
                    yield return txs1;
                    break;
                case InnerSubstrateTxStatus.Broadcast:
                    var txs2 = new TxStatus();
                    txs2.Init(InnerTxStatus.Broadcast, status.Value2);
                    yield return txs2;
                    break;
                case InnerSubstrateTxStatus.InBlock:
                    var txs3 = new TxStatus();
                    Hash extHash = new Hash();
                    extHash.Init(this.extHash);
                    var inBlock = new TxInBlock((Hash)status.Value2, extHash, client);
                    txs3.Init(InnerTxStatus.InBlock, inBlock);
                    yield return txs3;
                    break;
                case InnerSubstrateTxStatus.Retracted:
                    var txs4 = new TxStatus();
                    txs4.Init(InnerTxStatus.Retracted, status.Value2);
                    yield return txs4;
                    break;
                case InnerSubstrateTxStatus.Usurped:
                    var txs5 = new TxStatus();
                    txs5.Init(InnerTxStatus.Usurped, status.Value2);
                    yield return txs5;
                    break;
                case InnerSubstrateTxStatus.Dropped:
                    var txs6 = new TxStatus();
                    txs6.Init(InnerTxStatus.Dropped, status.Value2);
                    yield return txs6;
                    break;
                case InnerSubstrateTxStatus.Invalid:
                    var txs7 = new TxStatus();
                    txs7.Init(InnerTxStatus.Invalid, status.Value2);
                    yield return txs7;
                    break;
                // Only the following statuses are actually considered "final" (see the substrate
                // docs on `TxStatus`). Basically, either the transaction makes it into a
                // block, or we eventually give up on waiting for it to make it into a block.
                // Even `Dropped`/`Invalid`/`Usurped` transactions might make it into a block eventually.
                //
                // As an example, a transaction that is `Invalid` on one node due to having the wrong
                // nonce might still be valid on some fork on another node which ends up being finalized.
                // Equally, a transaction `Dropped` from one node may still be in the transaction pool,
                // and make it into a block, on another node. Likewise with `Usurped`.
                case InnerSubstrateTxStatus.FinalityTimeout:
                    sub!.Unsubscribe();
                    //sub = null; ??
                    var txs8 = new TxStatus();
                    txs8.Init(InnerTxStatus.FinalityTimeout, status.Value2);
                    yield return txs8;
                    break;
                case InnerSubstrateTxStatus.Finalized:
                    sub!.Unsubscribe();
                    var txs9 = new TxStatus();
                    Hash extHash1 = new Hash();
                    extHash1.Init(this.extHash);
                    var inBlock1 = new TxInBlock((Hash)status.Value2, extHash1, client);
                    txs9.Init(InnerTxStatus.Finalized, inBlock1);
                    yield return txs9;
                    break;
                default:
                    break;
            }
        }
        sub = null;
    }

    /// <summary>
    /// Wait for the transaction to be in a block (but not necessarily finalized), and return
    /// an [`TxInBlock`] instance when this happens, or an error if there was a problem
    /// waiting for this to happen.
    ///
    /// **Note:** consumes `self`. If you'd like to perform multiple actions as the state of the
    /// transaction progresses, use [`TxProgress::next_item()`] instead.
    ///
    /// **Note:** transaction statuses like `Invalid` and `Usurped` are ignored, because while they
    /// may well indicate with some probability that the transaction will not make it into a block,
    /// there is no guarantee that this is true. Thus, we prefer to "play it safe" here. Use the lower
    /// level [`TxProgress::next_item()`] API if you'd like to handle these statuses yourself.
    /// </summary>
    /// <returns></returns>
    public async Task<TxInBlock> WaitForInBlock()
    {
        await foreach (var status in NextItem())
        {
            switch (status.Value)
            {
                // Finalized or otherwise in a block! Return.
                case InnerTxStatus.InBlock or InnerTxStatus.Finalized:
                    return (TxInBlock)status.Value2;
                case InnerTxStatus.FinalityTimeout:
                    throw new FinalitySubscriptionTimeoutException(extHash);
                // Ignore anything else and wait for next status event:
                default:
                    break;
            }
        }
        throw new SubscriptionDroppedException();
    }

    /// <summary>
    /// Wait for the transaction to be finalized, and return a [`TxInBlock`]
    /// instance when it is, or an error if there was a problem waiting for finalization.
    ///
    /// **Note:** consumes `self`. If you'd like to perform multiple actions as the state of the
    /// transaction progresses, use [`TxProgress::next_item()`] instead.
    ///
    /// **Note:** transaction statuses like `Invalid` and `Usurped` are ignored, because while they
    /// may well indicate with some probability that the transaction will not make it into a block,
    /// there is no guarantee that this is true. Thus, we prefer to "play it safe" here. Use the lower
    /// level [`TxProgress::next_item()`] API if you'd like to handle these statuses yourself.
    /// </summary>
    /// <returns></returns>
    public async Task<TxInBlock> WaitForFinalized()
    {
        await foreach (var status in NextItem())
        {
            switch (status.Value)
            {
                // Finalized! Return.
                case InnerTxStatus.Finalized:
                    return (TxInBlock)status.Value2;
                case InnerTxStatus.FinalityTimeout:
                    throw new FinalitySubscriptionTimeoutException(extHash);
                // Ignore and wait for next status event:
                default:
                    break;
            }
        }
        throw new SubscriptionDroppedException();
    }

    /// <summary>
    /// Wait for the transaction to be finalized, and for the transaction events to indicate
    /// that the transaction was successful. Returns the events associated with the transaction,
    /// as well as a couple of other details (block hash and extrinsic hash).
    ///
    /// **Note:** consumes self. If you'd like to perform multiple actions as progress is made,
    /// use [`TxProgress::next_item()`] instead.
    ///
    /// **Note:** transaction statuses like `Invalid` and `Usurped` are ignored, because while they
    /// may well indicate with some probability that the transaction will not make it into a block,
    /// there is no guarantee that this is true. Thus, we prefer to "play it safe" here. Use the lower
    /// level [`TxProgress::next_item()`] API if you'd like to handle these statuses yourself.
    /// </summary>
    /// <returns></returns>
    public async Task<ExtrinsicEvents> WaitForFinalizedSuccess()
    {
        var fin = await WaitForFinalized();
        return await fin.WaitForSuccess();
    }
}

