using System;
using Chaos.NaCl;
using FinalBiome.Api.Types;
using FinalBiome.Api.Types.SpRuntime;
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
        MiniSecret ms = new MiniSecret(seed, ExpandMode.Ed25519);
        return new Account(SignatureType.Sr25519, ms.ExpandToSecret().ToBytes(), ms.GetPair().Public.Key);
    }

    public MultiSignature Sign(byte[] payload)
    {
        Codec signatureData;

        switch (signatureType)
        {
            case SignatureType.Ed25519:
                signatureData = new FinalBiome.Api.Types.SpCore.Ed25519.Signature();
                signatureData.Init(Ed25519.Sign(payload, privateKey));
                break;
            case SignatureType.Sr25519:
                signatureData = new FinalBiome.Api.Types.SpCore.Sr25519.Signature();
                signatureData.Init(Sr25519v091.SignSimple(publicKey, privateKey, payload));
                break;
            default:
                throw new NotImplementedException($"Singature of {signatureType} type is not implemented");
        }

        MultiSignature signature = new MultiSignature();
        signature.Init(signatureType, signatureData);
        return signature;
    }
}

