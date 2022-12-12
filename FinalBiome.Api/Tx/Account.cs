using System;
using Chaos.NaCl;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.SpCore.Crypto;
using FinalBiome.Api.Types.SpRuntime;
using FinalBiome.Api.Types.SpRuntime.Multiaddress;
using FinalBiome.Api.Utils;
using Schnorrkel;
using Schnorrkel.Keys;

namespace FinalBiome.Api.Tx;

using SignatureType = InnerMultiSignature;

/// <summary>
/// Inplementation of the <see cref="Pair"/> interface for the possibility to signing transactions
/// </summary>
public class Account : Pair
{
    readonly SignatureType signatureType;
    readonly byte[] privateKey;
    readonly byte[] publicKey;

    public Account(SignatureType signatureType, byte[] privateKey, byte[] publicKey)
    {
        this.signatureType = signatureType;
        this.privateKey = privateKey;
        this.publicKey = publicKey;
    }

    public byte[] PublicKey()
    {
        return publicKey;
    }

    public static Account FromSeed(SignatureType signatureType, byte[] seed)
    {
        if (signatureType != SignatureType.Sr25519) throw new NotImplementedException($"Signature type {signatureType} is not implemented");
        MiniSecret ms = new(seed, ExpandMode.Ed25519);
        return new Account(SignatureType.Sr25519, ms.ExpandToSecret().ToBytes(), ms.GetPair().Public.Key);
    }

    public MultiSignature Sign(byte[] payload)
    {
        Codec signatureData;

        switch (signatureType)
        {
            case SignatureType.Ed25519:
                signatureData = new Types.SpCore.Ed25519.Signature();
                signatureData.Init(Ed25519.Sign(payload, privateKey));
                break;
            case SignatureType.Sr25519:
                signatureData = new Types.SpCore.Sr25519.Signature();
                signatureData.Init(Sr25519v091.SignSimple(publicKey, privateKey, payload));
                break;
            default:
                throw new NotImplementedException($"Singature of {signatureType} type is not implemented");
        }

        MultiSignature signature = new();
        signature.Init(signatureType, signatureData);
        return signature;
    }

    public MultiAddress ToAddress()
    {
        MultiAddress address = new();
        AccountId32 accountId32 = new();
        accountId32.Init(PublicKey());
        address.Init(InnerMultiAddress.Id, accountId32);
        return address;
    }

    public string ToSS58Address()
    {
        return AddressUtils.GetAddressFrom(PublicKey());
    }

    public static implicit operator AccountId32(Account a)
    {
        AccountId32 accountId32 = new();
        accountId32.Init(a.PublicKey());
        return accountId32;
    }
}

