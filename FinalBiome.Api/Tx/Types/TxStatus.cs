#pragma warning disable CS8618
using System;
using FinalBiome.Api.Blocks;
using FinalBiome.Api.Events;
using FinalBiome.Api.Tx.Errors;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Tx;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;

public enum InnerTxStatus : byte
{
    /// <summary>
    /// The transaction is part of the "future" queue.
    /// </summary>
    Future,
    /// <summary>
    /// The transaction is part of the "ready" queue.
    /// </summary>
    Ready,
    /// <summary>
    /// The transaction has been broadcast to the given peers.
    /// </summary>
    Broadcast,
    /// <summary>
    /// The transaction has been included in a block with given hash.
    /// </summary>
    InBlock,
    /// <summary>
    /// The block this transaction was included in has been retracted,
    /// probably because it did not make it onto the blocks which were
    /// finalized.
    /// </summary>
    Retracted,
    /// <summary>
    /// A block containing the transaction did not reach finality within 512
    /// blocks, and so the subscription has ended.
    /// </summary>
    FinalityTimeout,
    /// <summary>
    /// The transaction has been finalized by a finality-gadget, e.g GRANDPA.
    /// </summary>
    Finalized,
    /// <summary>
    /// The transaction has been replaced in the pool by another transaction
    /// that provides the same tags. (e.g. same (sender, nonce)).
    /// </summary>
    Usurped,
    /// <summary>
    /// The transaction has been dropped from the pool because of the limit.
    /// </summary>
    Dropped,
    /// <summary>
    /// The transaction is no longer valid in the current state.
    /// </summary>
    Invalid,
}

/// <summary>
/// Dev note: The below is adapted from the substrate docs on `TxStatus`, which this
/// enum was adapted from (and which is an exact copy of `SubstrateTxStatus` in this crate).
/// Note that the number of finality watchers is, at the time of writing, found in the constant
/// `MAX_FINALITY_WATCHERS` in the `sc_transaction_pool` crate.
/// <br/>
/// Possible transaction statuses returned from our [`TxProgress::next_item()`] call.
///<br/>
/// These status events can be grouped based on their kinds as:
///<br/>
/// 1. Entering/Moving within the pool:<br/>
///    - `Future`<br/>
///    - `Ready`<br/>
/// 2. Inside `Ready` queue:<br/>
///    - `Broadcast`<br/>
/// 3. Leaving the pool:<br/>
///    - `InBlock`<br/>
///    - `Invalid`<br/>
///    - `Usurped`<br/>
///    - `Dropped`<br/>
/// 4. Re-entering the pool:<br/>
///    - `Retracted`<br/>
/// 5. Block finalized:<br/>
///    - `Finalized`<br/>
///    - `FinalityTimeout`<br/>
///<br/>
/// The events will always be received in the order described above, however
/// there might be cases where transactions alternate between `Future` and `Ready`
/// pool, and are `Broadcast` in the meantime.
///<br/>
/// Note that there are conditions that may cause transactions to reappear in the pool:
///<br/>
/// 1. Due to possible forks, the transaction that ends up being included
///    in one block may later re-enter the pool or be marked as invalid.<br/>
/// 2. A transaction that is `Dropped` at one point may later re-enter the pool if
///    some other transactions are removed.<br/>
/// 3. `Invalid` transactions may become valid at some point in the future.
///    (Note that runtimes are encouraged to use `UnknownValidity` to inform the
///    pool about such cases).<br/>
/// 4. `Retracted` transactions might be included in a future block.<br/>
///<br/>
/// The stream is considered finished only when either the `Finalized` or `FinalityTimeout`
/// event is triggered. You are however free to unsubscribe from notifications at any point.
/// The first one will be emitted when the block in which the transaction was included gets
/// finalized. The `FinalityTimeout` event will be emitted when the block did not reach finality
/// within 512 blocks. This either indicates that finality is not available for your chain,
/// or that finality gadget is lagging behind.
/// </summary>
public class TxStatus : Enum<InnerTxStatus,
                             BaseVoid,  // Future
                             BaseVoid,  // Ready
                             Vec<Str>,  // Broadcast
                             TxInBlock, // InBlock
                             Hash,      // Retracted
                             Hash,      // FinalityTimeout
                             TxInBlock, // Finalized
                             Hash,      // Usurped
                             BaseVoid,  // Dropped
                             BaseVoid   // Invalid
                             >
{
    public override string TypeName() => "TxStatus";

    /// <summary>
    /// A convenience method to return the `Finalized` details. Returns
    /// [`null`] if the enum variant is not [`TxStatus::Finalized`].
    /// </summary>
    /// <returns></returns>
    public TxInBlock? AsFinalized()
    {
        if (Value == InnerTxStatus.Finalized) return (TxInBlock)Value2;
        else return null;
    }

    /// <summary>
    /// A convenience method to return the `InBlock` details. Returns
    /// [`null`] if the enum variant is not [`TxStatus::InBlock`].
    /// </summary>
    /// <returns></returns>
    public TxInBlock? AsInBlock()
    {
        if (Value == InnerTxStatus.InBlock) return (TxInBlock)Value2;
        else return null;
    }
}

/// <summary>
/// This struct represents a transaction that has made it into a block.
/// </summary>
public class TxInBlock : Codec
{
    readonly Hash blockHash;
    readonly Hash extHash;
    readonly Client client;

    public TxInBlock(Hash blockHash, Hash extHash, Client client)
    {
        this.blockHash = blockHash;
        this.extHash = extHash;
        this.client = client;
    }

    public TxInBlock() { } // For Enum compliance

    /// <summary>
    /// Return the hash of the block that the transaction has made it into.
    /// </summary>
    public Hash BlockHash => blockHash;

    /// <summary>
    /// Return the hash of the extrinsic that was submitted.
    /// </summary>
    public Hash ExtrinsicHash => extHash;

    /// <summary>
    /// Fetch the events associated with this transaction. If the transaction
    /// was successful (ie no `ExtrinsicFailed`) events were found, then we return
    /// the events associated with it. If the transaction was not successful, or
    /// something else went wrong, we return an error.
    ///
    /// **Note:** If multiple `ExtrinsicFailed` errors are returned (for instance
    /// because a pallet chooses to emit one as an event, which is considered
    /// abnormal behaviour), it is not specified which of the errors is returned here.
    /// You can use [`TxInBlock::fetch_events`] instead if you'd like to
    /// work with multiple "error" events.
    ///
    /// **Note:** This has to download block details from the node and decode events
    /// from them.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ExtrinsicFailedException"></exception>
    public async Task<ExtrinsicEvents> WaitForSuccess()
    {
        var events = await FetchEvents();
        // Try to find any errors; return the first one we encounter.
        foreach (var evr in events)
        {
            var ev = evr.Event;
            if (ev.Value == Types.FinalbiomeNodeRuntime.InnerEvent.System)
            {
                FinalBiome.Api.Types.FrameSystem.Pallet.Event eventData = (FinalBiome.Api.Types.FrameSystem.Pallet.Event)ev.Value2;
                if (eventData.Value == Types.FrameSystem.Pallet.InnerEvent.ExtrinsicFailed)
                {
                    FinalBiome.Api.Types.FrameSystem.Pallet.EventExtrinsicFailed fieldData = (FinalBiome.Api.Types.FrameSystem.Pallet.EventExtrinsicFailed)eventData.Value2;
                    var dispatchError = fieldData.DispatchError;
                    throw new ExtrinsicFailedException(this.extHash, dispatchError);
                }
            }
        }
        return events;
    }

    /// <summary>
    /// Fetch all of the events associated with this transaction. This succeeds whether
    /// the transaction was a success or not; it's up to you to handle the error and
    /// success events however you prefer.
    ///
    /// **Note:** This has to download block details from the node and decode events
    /// from them.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ExtrinsicEvents> FetchEvents()
    {
        var block = await client.Rpc.Block(blockHash);
        int extrinsicIdx = Array.FindIndex(
            block.Block.Extrinsics.Value,
            v => Enumerable.SequenceEqual(Hasher.BlakeTwo256(v.Bytes), extHash.Bytes)
        );
        // If we successfully obtain the block hash we think contains our
        // extrinsic, the extrinsic should be in there somewhere..
        if (extrinsicIdx == -1) throw new BlockHashNotFoundException(extHash);

        var eventsClient = new EventsClient(client);
        var events = await eventsClient.At(blockHash);

        return new ExtrinsicEvents(extHash, extrinsicIdx, events);
    }

    public override string TypeName() => "TxInBlock";

    public override byte[] Encode()
    {
        var bytes = new List<byte>();

        bytes.AddRange(BlockHash.Encode());
        bytes.AddRange(ExtrinsicHash.Encode());

        return bytes.ToArray();
    }

    public override void Decode(byte[] bytes, ref int pos)
    {
        throw new NotImplementedException();
    }
}
