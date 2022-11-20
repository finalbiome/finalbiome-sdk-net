using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Rpc.Types;

using DispatchError = FinalBiome.Api.Types.SpRuntime.DispatchError;

/// <summary>
/// The result of applying of an extrinsic.
///
/// This type is typically used in the context of `BlockBuilder` to signal that the extrinsic
/// in question cannot be included.
///
/// A block containing extrinsics that have a negative inclusion outcome is invalid. A negative
/// result can only occur during the block production, where such extrinsics are detected and
/// removed from the block that is being created and the transaction pool.
///
/// To rehash: every extrinsic in a valid block must return a positive `ApplyExtrinsicResult`.
///
/// Examples of reasons preventing inclusion in a block:
/// - More block weight is required to process the extrinsic than is left in the block being built.
///   This doesn't necessarily mean that the extrinsic is invalid, since it can still be included in
///   the next block if it has enough spare weight available.
/// - The sender doesn't have enough funds to pay the transaction inclusion fee. Including such a
///   transaction in the block doesn't make sense.
/// - The extrinsic supplied a bad signature. This transaction won't become valid ever.
/// </summary>
public class ApplyExtrinsicResult : Result<DispatchOutcome, TransactionValidityError>
{
    public override string TypeName() => "ApplyExtrinsicResult";
}

/// <summary>
/// This type specifies the outcome of dispatching a call to a module.
///
/// In case of failure an error specific to the module is returned.
///
/// Failure of the module call dispatching doesn't invalidate the extrinsic and it is still included
/// in the block, therefore all state changes performed by the dispatched call are still persisted.
///
/// For example, if the dispatching of an extrinsic involves inclusion fee payment then these
/// changes are going to be preserved even if the call dispatched failed.
/// </summary>
public class DispatchOutcome : Result<FinalBiome.Api.Types.Tuple<BaseVoid>, DispatchError>
{
    public override string TypeName() => "DispatchOutcome";
}

public enum InnerTransactionValidityError : byte
{
    /// <summary>
    /// The transaction is invalid.
    /// </summary>
	Invalid,
    /// <summary>
    /// Transaction validity can't be determined.
    /// </summary>
    Unknown,
}

public class TransactionValidityError : Enum<InnerTransactionValidityError, InvalidTransaction, UnknownTransaction>
{
    public override string TypeName() => "TransactionValidityError";
}

public enum InnerInvalidTransaction : byte
{
    /// The call of the transaction is not expected.
	Call,
    /// General error to do with the inability to pay some fees (e.g. account balance too low).
    Payment,
    /// General error to do with the transaction not yet being valid (e.g. nonce too high).
    Future,
    /// General error to do with the transaction being outdated (e.g. nonce too low).
    Stale,
    /// General error to do with the transaction's proofs (e.g. signature).
    ///
    /// # Possible causes
    ///
    /// When using a signed extension that provides additional data for signing, it is required
    /// that the signing and the verifying side use the same additional data. Additional
    /// data will only be used to generate the signature, but will not be part of the transaction
    /// itself. As the verifying side does not know which additional data was used while signing
    /// it will only be able to assume a bad signature and cannot express a more meaningful error.
    BadProof,
    /// The transaction birth block is ancient.
    ///
    /// # Possible causes
    ///
    /// For `FRAME`-based runtimes this would be caused by `current block number
    /// - Era::birth block number > BlockHashCount`. (e.g. in Polkadot `BlockHashCount` = 2400, so
    ///   a
    /// transaction with birth block number 1337 would be valid up until block number 1337 + 2400,
    /// after which point the transaction would be considered to have an ancient birth block.)
    AncientBirthBlock,
    /// The transaction would exhaust the resources of current block.
    ///
    /// The transaction might be valid, but there are not enough resources
    /// left in the current block.
    ExhaustsResources,
    /// Any other custom invalid validity that is not covered by this enum.
    Custom,
    /// An extrinsic with a Mandatory dispatch resulted in Error. This is indicative of either a
    /// malicious validator or a buggy `provide_inherent`. In any case, it can result in
    /// dangerously overweight blocks and therefore if found, invalidates the block.
    BadMandatory,
    /// A transaction with a mandatory dispatch. This is invalid; only inherent extrinsics are
    /// allowed to have mandatory dispatches.
    MandatoryDispatch,
    /// The sending address is disabled or known to be invalid.
    BadSigner
}

/// <summary>
/// An invalid transaction validity.
/// </summary>
public class InvalidTransaction : Enum<InnerInvalidTransaction,
                                       BaseVoid,
                                       BaseVoid,
                                       BaseVoid,
                                       BaseVoid,
                                       BaseVoid,
                                       BaseVoid,
                                       BaseVoid,
                                       U8,
                                       BaseVoid,
                                       BaseVoid,
                                       BaseVoid>
{
    public override string TypeName() => "InvalidTransaction";
}

public enum InnerUnknownTransaction : byte
{
    /// Could not lookup some information that is required to validate the transaction.
    CannotLookup,
    /// No validator found for the given unsigned transaction.
    NoUnsignedValidator,
    /// Any other custom unknown validity that is not covered by this enum.
    Custom,
}

public class UnknownTransaction : Enum<InnerUnknownTransaction,
                                       BaseVoid,
                                       BaseVoid,
                                       U8>
{
    public override string TypeName() => "UnknownTransaction";
}
