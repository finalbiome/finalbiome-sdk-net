using FinalBiome.Api.Types.Primitive;
using FinalBiome.Api.Utils;
using FinalBiome.Api.Extensions;
using FinalBiome.Api.Types;

namespace FinalBiome.Api.Tx;

using Index = U32;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
using Signature = FinalBiome.Api.Types.SpRuntime.MultiSignature;

/// <summary>
/// A client for working with transactions.
/// </summary>
public partial class TxClient
{
    /// <summary>
    /// Return the SCALE encoded bytes representing the call data of the transaction.
    /// </summary>
    /// <param name="call"></param>
    /// <returns></returns>
    public static List<byte> CallData(TxPayload call)
    {
        List<byte> bytes = new();
        call.EncodeCallDataTo(ref bytes);
        return bytes;
    }

    /// <summary>
    /// Creates an unsigned extrinsic without submitting it.
    /// </summary>
    /// <param name="call"></param>
    /// <returns></returns>
    public SubmittableExtrinsic CreateUnsigned(TxPayload call)
    {
        // Encode extrinsic
        List<byte> encodedInner = new();
        // transaction protocol version (4) (is not signed, so no 1 bit at the front).
        U8.From(4).EncodeTo(ref encodedInner);
        // encode call data after this byte.
        call.EncodeCallDataTo(ref encodedInner);
        // now, prefix byte length:
        var len = encodedInner.Count;
        var encodedLen = CompactNum.CompactTo(len);

        List<byte> extrinsic = new();
        extrinsic.AddRange(encodedLen);
        extrinsic.AddRange(encodedInner);

        return SubmittableExtrinsic.FromBytes(client, extrinsic);
    }

    public SubmittableExtrinsic CreateSignedWithNonce(
        TxPayload call,
        Signer signer,
        ulong accountNonce,
        BaseExtrinsicParamsBuilder<PlainTip> otherParams // TODO: refact hardcoded types
        )
    {
        // 1. SCALE encode call data to bytes (pallet u8, call u8, call params).
        var callData = CallData(call);

        // 2. Construct our custom additional/extra params.
        var runtime = client.RuntimeVersion;
        var additionalAndExtraParams = new BaseExtrinsicParams<PlainTip>( // TODO: refact hardcoded types
            runtime.SpecVersion,
            runtime.TransactionVersion,
            accountNonce,
            client.GenesisHash,
            otherParams
            );

        // 3. Construct signature. This is compatible with the Encode impl
        //    for SignedPayload (which is this payload of bytes that we'd like)
        //    to sign. See:
        //    https://github.com/paritytech/substrate/blob/9a6d706d8db00abb6ba183839ec98ecd9924b1f8/primitives/runtime/src/generic/unchecked_extrinsic.rs#L215)
        List<byte> bytes = new();
        callData.EncodeTo(ref bytes); // already encoded
        additionalAndExtraParams.EncodeExtraTo(ref bytes);
        additionalAndExtraParams.EncodeAdditionalTo(ref bytes);
        Signature signature;
        if (bytes.Count > 256)
        {
            signature = signer.Sign(Hasher.BlakeTwo256(bytes.ToArray()));
        }
        else
        {
            signature = signer.Sign(bytes.ToArray());
        }

        // 4. Encode extrinsic, now that we have the parts we need. This is compatible
        //    with the Encode impl for UncheckedExtrinsic (protocol version 4).
        List<byte> encodedInner = new();
        // "is signed" + transaction protocol version (4)
        ((byte)(0b10000000 + 4)).EncodeTo(ref encodedInner);
        // from address for signature
        signer.Address.EncodeTo(ref encodedInner);
        // the signature bytes
        signature.EncodeTo(ref encodedInner);
        // attach custom extra params
        additionalAndExtraParams.EncodeExtraTo(ref encodedInner);
        // and now, call data
        callData.EncodeTo(ref encodedInner);
        // now, prefix byte length:
        var len = encodedInner.Count;
        var encodedLen = CompactNum.CompactTo(len);

        List<byte> extrinsic = new();
        extrinsic.AddRange(encodedLen);
        extrinsic.AddRange(encodedInner);

        // Wrap in Encoded to ensure that any more "encode" calls leave it in the right state.
        // maybe we can just return the raw bytes..
        return SubmittableExtrinsic.FromBytes(
            client,
            extrinsic
            );
    }

    /// <summary>
    /// Creates a raw signed extrinsic, without submitting it.
    /// </summary>
    /// <returns></returns>
    public async Task<SubmittableExtrinsic> CreateSigned(
        TxPayload call,
        Signer signer,
        BaseExtrinsicParamsBuilder<PlainTip> otherParams
        )
    {
        // Get nonce from the node.
        var accountNonce = await client.Rpc.SystemAccountNextIndex(signer.AccountId);
        return CreateSignedWithNonce(call, signer, accountNonce, otherParams);
    }

    /// <summary>
    /// Creates and signs an extrinsic and submits it to the chain. Passes default parameters
    /// to construct the "signed extra" and "additional" payloads needed by the extrinsic.
    ///
    /// Returns a [`TxProgress`], which can be used to track the status of the transaction
    /// and obtain details about it, once it has made it into a block.
    /// </summary>
    /// <param name="call"></param>
    /// <param name="signer"></param>
    /// <returns></returns>
    public async Task<TxProgress> SignAndSubmitThenWatchDefault(
        TxPayload call,
        Signer signer
        )
    {
        BaseExtrinsicParamsBuilder<PlainTip> otherParams = BaseExtrinsicParamsBuilder<PlainTip>.Default();
        return await SignAndSubmitThenWatch(call, signer, otherParams);
    }

    /// <summary>
    /// Creates and signs an extrinsic and submits it to the chain.
    ///
    /// Returns a [`TxProgress`], which can be used to track the status of the transaction
    /// and obtain details about it, once it has made it into a block.
    /// </summary>
    /// <param name="call"></param>
    /// <param name="signer"></param>
    /// <param name="otherParams"></param>
    /// <returns></returns>
    public async Task<TxProgress> SignAndSubmitThenWatch(
        TxPayload call,
        Signer signer,
        BaseExtrinsicParamsBuilder<PlainTip> otherParams
        )
    {
        var subExt = await CreateSigned(call, signer, otherParams);
        return await subExt.SubmitAndWatch();
    }

    /// <summary>
    /// Creates and signs an extrinsic and submits to the chain for block inclusion. Passes
    /// default parameters to construct the "signed extra" and "additional" payloads needed
    /// by the extrinsic.
    ///
    /// Returns `Ok` with the extrinsic hash if it is valid extrinsic.
    ///
    /// # Note
    ///
    /// Success does not mean the extrinsic has been included in the block, just that it is valid
    /// and has been included in the transaction pool.
    /// </summary>
    /// <param name="call"></param>
    /// <param name="signer"></param>
    /// <returns></returns>
    public async Task<Hash> SignAndSubmitDefault(
        TxPayload call,
        Signer signer
        )
    {
        BaseExtrinsicParamsBuilder<PlainTip> otherParams = BaseExtrinsicParamsBuilder<PlainTip>.Default();
        return await SignAndSubmit(call, signer, otherParams);
    }

    public async Task<Hash> SignAndSubmit(
        TxPayload call,
        Signer signer,
        BaseExtrinsicParamsBuilder<PlainTip> otherParams
        )
    {
        var subExt = await CreateSigned(call, signer, otherParams);
        return await subExt.Submit();
    }
}
