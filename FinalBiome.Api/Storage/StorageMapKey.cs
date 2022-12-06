using System;
using FinalBiome.Api.Types;
using FinalBiome.Api.Utils;

namespace FinalBiome.Api.Storage;

/// <summary>
/// Storage key for a Map.
/// </summary>
public class StorageMapKey
{
    readonly byte[] value;
    readonly StorageHasher hasher;

    public StorageMapKey(
        Codec value,
        StorageHasher hasher
        )
    {
        this.value = value.Encode();
        this.hasher = hasher;
    }
    /// <summary>
    /// Convert this [`StorageMapKey`] into bytes and append them to some existing bytes.
    /// </summary>
    /// <returns></returns>
    public void ToBytes(ref List<byte> bytes)
    {
        StorageMapKey.HashBytes(value, hasher, ref bytes);
    }

    /// <summary>
    /// Take some SCALE encoded bytes and a [`StorageHasher`] and hash the bytes accordingly.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="hasher"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static void HashBytes(byte[] input, StorageHasher hasher, ref List<byte> bytes)
    {
        switch (hasher)
        {
            case StorageHasher.Identity:
                bytes.AddRange(input);
                break;
            case StorageHasher.Blake2_128:
                bytes.AddRange(Hasher.BlakeTwo128(input));
                break;
            case StorageHasher.Blake2_128Concat:
                bytes.AddRange(Hasher.BlakeTwo128Concat(input));
                break;
            case StorageHasher.Blake2_256:
                bytes.AddRange(Hasher.BlakeTwo256(input));
                break;
            case StorageHasher.Twox128:
                bytes.AddRange(Hasher.Twox128(input));
                break;
            case StorageHasher.Twox256:
                bytes.AddRange(Hasher.Twox256(input));
                break;
            case StorageHasher.Twox64Concat:
                bytes.AddRange(Hasher.Twox64Concat(input));
                break;

            default:
                throw new NotImplementedException($"StorageHasher {hasher} is not implement");
        }
    }
}

/// <summary>
/// Hasher used by storage maps (from frame-metadata v14)
/// </summary>
public enum StorageHasher
{
    /// <summary>
    /// 128-bit Blake2 hash.
    /// </summary>
    Blake2_128,
    /// <summary>
    /// 256-bit Blake2 hash.
    /// </summary>
    Blake2_256,
    /// <summary>
    /// Multiple 128-bit Blake2 hashes concatenated.
    /// </summary>
    Blake2_128Concat,
    /// <summary>
    /// 128-bit XX hash.
    /// </summary>
    Twox128,
    /// <summary>
    /// 256-bit XX hash.
    /// </summary>
    Twox256,
    /// <summary>
    /// Multiple 64-bit XX hashes concatenated.
    /// </summary>
    Twox64Concat,
    /// <summary>
    /// Identity hashing (no hashing).
    /// </summary>
    Identity,
}
