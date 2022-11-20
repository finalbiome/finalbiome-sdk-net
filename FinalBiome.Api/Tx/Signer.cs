using System;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Tx;

using AccountId = FinalBiome.Api.Types.SpCore.Crypto.AccountId32;
using Address = FinalBiome.Api.Types.SpRuntime.Multiaddress.MultiAddress;
using Signature = FinalBiome.Api.Types.SpRuntime.MultiSignature;
/// <summary>
/// Signing transactions requires a [`Signer`]. This is responsible for
/// providing the "from" account that the transaction is being signed by,
/// as well as actually signing a SCALE encoded payload.
/// </summary>
public interface Signer
{
    /// <summary>
    /// Return the "from" account ID.
    /// </summary>
    /// <returns></returns>
    AccountId AccountId();

    /// <summary>
    /// Return the "from" address.
    /// </summary>
    /// <returns></returns>
    Address Address();

    /// <summary>
    /// Takes a signer payload for an extrinsic, and returns a signature based on it.
    ///
    /// Some signers may fail, for instance because the hardware on which the keys are located has
    /// refused the operation.
    /// </summary>
    /// <param name="signerPayload"></param>
    /// <returns></returns>
    Signature Sign(byte[] signerPayload);
}

/// <summary>
///  A [`Signer`] implementation that can be constructed from an [`Pair`].
/// </summary>
public class PairSigner : Signer
{
    AccountId accountId;
    Pair signer;

    public PairSigner(Pair signer)
    {
        var accountId = new AccountId();
        accountId.Init(signer.PublicKey());
        this.accountId = accountId;
        this.signer = signer;
    }

    /// <summary>
    /// Returns the [`Pair`] implementation used to construct this.
    /// </summary>
    public Pair Signer => this.signer;

    public Address Address()
    {
        var addr = new Address();
        addr.Init(Types.SpRuntime.Multiaddress.InnerMultiAddress.Id, accountId);
        return addr;
    }

    public Signature Sign(byte[] signerPayload)
    {
        return this.signer.Sign(signerPayload);
    }

    public AccountId AccountId()
    {
        return accountId;
    }
}

public interface Pair
{
    byte[] PublicKey();
    Signature Sign(byte[] payload);
}

