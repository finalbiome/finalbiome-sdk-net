using System.Linq;
using FinalBiome.Api.Extensions;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.SpRuntime.Generic.Era;
using FinalBiome.Api.Utils;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Tx;

using Index = FinalBiome.Api.Types.Primitive.U32;
using Hash = FinalBiome.Api.Types.PrimitiveTypes.H256;
/// <summary>
/// This trait allows you to configure the "signed extra" and
/// "additional" parameters that are signed and used in transactions.
/// see [`BaseExtrinsicParams`] for an implementation that is compatible with
/// a Polkadot node.
/// </summary>
public interface ExtrinsicParams
{
    /// <summary>
    /// This is expected to SCALE encode the "signed extra" parameters
    /// to some buffer that has been provided. These are the parameters
    /// which are sent along with the transaction, as well as taken into
    /// account when signing the transaction.
    /// </summary>
    /// <param name="bytes"></param>
    public void EncodeExtraTo(ref List<byte> bytes);
    /// <summary>
    /// This is expected to SCALE encode the "additional" parameters
    /// to some buffer that has been provided. These parameters are _not_
    /// sent along with the transaction, but are taken into account when
    /// signing it, meaning the client and node must agree on their values.
    /// </summary>
    /// <param name="bytes"></param>
    public void EncodeAdditionalTo(ref List<byte> bytes);
}

/// <summary>
/// An implementation of [`ExtrinsicParams`] that is suitable for constructing
/// extrinsics that can be sent to a node with the same signed extra and additional
/// parameters as a Polkadot/Substrate node. The way that tip payments are specified
/// differs between Substrate and Polkadot nodes, and so we are generic over that in
/// order to support both here with relative ease.
///
/// If your node differs in the "signed extra" and "additional" parameters expected
/// to be sent/signed with a transaction, then you can define your own type which
/// implements the [`ExtrinsicParams`] trait.
/// </summary>
public class BaseExtrinsicParams<Tip> : ExtrinsicParams where Tip : Encode, new()
{
    readonly Era era;
    readonly ulong nonce;
    readonly Tip tip;
    readonly uint specVersion;
    readonly uint transactionVersion;
    readonly Hash genesisHash;
    readonly Hash mortalityCheckpoint;

    public BaseExtrinsicParams(uint specVersion,
                               uint transactionVersion,
                               ulong nonce,
                               Hash genesisHash,
                               // Provided externally:
                               BaseExtrinsicParamsBuilder<Tip> otherParams
                              )
    {
        this.era = otherParams.era;
        this.mortalityCheckpoint = otherParams.mortalityCheckpoint is not null ?
            otherParams.mortalityCheckpoint : genesisHash;
        this.tip = otherParams.tip;
        this.nonce = nonce;
        this.specVersion = specVersion;
        this.transactionVersion = transactionVersion;
        this.genesisHash = genesisHash;
    }

    public void EncodeExtraTo(ref List<byte> bytes)
    {
        byte[] tip = this.tip.Encode();
        this.era.EncodeTo(ref bytes);
        CompactNum.CompactTo(nonce).EncodeTo(ref bytes);
        tip.EncodeTo(ref bytes);
    }

    public void EncodeAdditionalTo(ref List<byte> bytes)
    {
        this.specVersion.EncodeTo(ref bytes);
        this.transactionVersion.EncodeTo(ref bytes);
        this.genesisHash.EncodeTo(ref bytes);
        this.mortalityCheckpoint.EncodeTo(ref bytes);
    }
}

/// <summary>
/// This builder allows you to provide the parameters that can be configured in order to
/// construct a [`BaseExtrinsicParams`] value. This implements [`Default`], which allows
/// [`BaseExtrinsicParams`] to be used with convenience methods like `sign_and_submit_default()`.
///
/// Prefer to use [`SubstrateExtrinsicParamsBuilder`] for a version of this tailored towards
/// Substrate, or [`PolkadotExtrinsicParamsBuilder`] for a version tailored to Polkadot.
/// </summary>
public class BaseExtrinsicParamsBuilder<Tip> where Tip : Encode, new()
{
    public Era era;
    public Hash? mortalityCheckpoint;
    public Tip tip;

    public BaseExtrinsicParamsBuilder(Era era, Hash? mortalityCheckpoint, Tip tip)
    {
        this.era = era;
        this.mortalityCheckpoint = mortalityCheckpoint;
        this.tip = tip;
    }

    /// <summary>
    /// Set the [`Era`], which defines how long the transaction will be valid for
    /// (it can be either immortal, or it can be mortal and expire after a certain amount
    /// of time). The second argument is the block hash after which the transaction
    /// becomes valid, and must align with the era phase (see the [`Era::Mortal`] docs
    /// for more detail on that).
    /// </summary>
    /// <param name="era"></param>
    /// <param name="checkpoint"></param>
    public BaseExtrinsicParamsBuilder<Tip> Era(Era era, Hash checkpoint)
    {
        this.era = era;
        this.mortalityCheckpoint = checkpoint;
        return this;
    }

    /// <summary>
    /// Set the tip you'd like to give to the block author
    /// for this transaction.
    /// </summary>
    /// <param name="tip"></param>
    /// <returns></returns>
    public BaseExtrinsicParamsBuilder<Tip> TipSet(Tip tip)
    {
        this.tip = tip;
        return this;
    }

    public static BaseExtrinsicParamsBuilder<Tip> Default()
    {
        Era era = new Era();
        era.Init(InnerEra.Immortal, new BaseVoid());
        return new BaseExtrinsicParamsBuilder<Tip>(
            era,
            null,
            new Tip()
            );
    }
}

/// <summary>
/// A builder which leads to [`SubstrateExtrinsicParams`] being constructed.
/// This is what you provide to methods like `sign_and_submit()`.
/// </summary>
public class SubstrateExtrinsicParamsBuilder : BaseExtrinsicParamsBuilder<AssetTip>
{
    public SubstrateExtrinsicParamsBuilder(Era era, Hash? mortalityCheckpoint, AssetTip tip) : base(era, mortalityCheckpoint, tip)
    {
    }
}

/// <summary>
/// A builder which leads to [`PolkadotExtrinsicParams`] being constructed.
/// This is what you provide to methods like `sign_and_submit()`.
/// </summary>
public class PolkadotExtrinsicParamsBuilder : BaseExtrinsicParamsBuilder<PlainTip>
{
    public PolkadotExtrinsicParamsBuilder(Era era, Hash? mortalityCheckpoint, PlainTip tip) : base(era, mortalityCheckpoint, tip)
    {
    }
}

/// <summary>
/// A tip payment.
/// </summary>
public class PlainTip: Encode
{
    readonly UInt128 tip;

    public PlainTip()
    {
        this.tip = 0;
    }

    public PlainTip(UInt128 tip)
    {
        this.tip = tip;
    }

    byte[] Encode.Encode()
    {
        return CompactNum.CompactTo(this.tip);
    }
}
/// <summary>
/// A tip payment made in the form of a specific asset.
/// </summary>
public class AssetTip : Encode
{
    readonly UInt128 tip;
    uint? asset;

    public AssetTip()
    {
        this.tip = 0;
    }

    /// <summary>
    /// Create a new tip of the amount provided.
    /// </summary>
    /// <param name="tip"></param>
    public AssetTip(UInt128 tip)
    {
        this.tip = tip;
        this.asset = null;
    }

    /// <summary>
    /// Designate the tip as being of a particular asset class.
    /// If this is not set, then the native currency is used.
    /// </summary>
    /// <param name="asset"></param>
    /// <returns></returns>
    public AssetTip OfAsset(uint asset)
    {
        this.asset = asset;
        return this;
    }

    byte[] Encode.Encode()
    {
        var a = new Option<U32>();
        if (asset is not null) a.Init(U32.From((uint)asset));

        return CompactNum.CompactTo(this.tip)
               .Concat(a.Encode()).ToArray();
    }
}