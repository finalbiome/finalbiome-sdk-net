using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Rpc.Types;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
public enum InnerSubstrateTxStatus : byte
{
    /// <summary>
    /// Transaction is part of the future queue.
    /// </summary>
    Future,
    /// <summary>
    /// Transaction is part of the ready queue.
    /// </summary>
    Ready,
    /// <summary>
    /// The transaction has been broadcast to the given peers.
    /// </summary>
    Broadcast,
    /// <summary>
    /// Transaction has been included in block with given hash.
    /// </summary>
    InBlock,
    /// <summary>
    /// The block this transaction was included in has been retracted.
    /// </summary>
    Retracted,
    /// <summary>
    /// Maximum number of finality watchers has been reached,
    /// old watchers are being removed.
    /// </summary>
    FinalityTimeout,
    /// <summary>
    /// Transaction has been finalized by a finality-gadget, e.g GRANDPA
    /// </summary>
    Finalized,
    /// <summary>
    /// Transaction has been replaced in the pool, by another transaction
    /// that provides the same tags. (e.g. same (sender, nonce)).
    /// </summary>
    Usurped,
    /// <summary>
    /// Transaction has been dropped from the pool because of the limit.
    /// </summary>
    Dropped,
    /// <summary>
    /// Transaction is no longer valid in the current state.
    /// </summary>
    Invalid,
}

/// <summary>
///  Possible transaction status events.
/// </summary>
public class SubstrateTxStatus : Enum<InnerSubstrateTxStatus,
                                      BaseVoid, // Future
                                      BaseVoid, // Ready
                                      Vec<Str>, // Broadcast
                                      Hash,     // InBlock
                                      Hash,     // Retracted
                                      Hash,     // FinalityTimeout
                                      Hash,     // Finalized
                                      Hash,     // Usurped
                                      BaseVoid, // Dropped
                                      BaseVoid  // Invalid
                                      >
{
    public override string TypeName() => "SubstrateTxStatus";
}

