﻿namespace FinalBiome.Api.Utils;
public class Hasher
{
    public static byte[] BlakeTwo(byte[] bytes, int size)
    {
        return Blake2Fast.Blake2b.ComputeHash(size, bytes);
    }

    public static byte[] BlakeTwo256(byte[] bytes)
    {
        return BlakeTwo(bytes, 32);
    }

    public static byte[] BlakeTwo128(byte[] bytes)
    {
        return BlakeTwo(bytes, 16);
    }

    public static byte[] BlakeTwo128Concat(byte[] bytes)
    {
        return BlakeTwo128(bytes).Concat(bytes).ToArray();
    }

    public static byte[] BlakeTwo256Concat(byte[] bytes)
    {
        return BlakeTwo256(bytes).Concat(bytes).ToArray();
    }
}
