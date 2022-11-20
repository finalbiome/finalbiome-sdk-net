using System.Buffers.Text;
using SimpleBase;
namespace FinalBiome.Api.Utils;

public class AddressUtils
{
    public static string GetAddressFrom(byte[] bytes, short ss58Prefix = 42)
    {
        // https://docs.substrate.io/v3/advanced/ss58/

        var SR25519_PUBLIC_SIZE = 32;
        var PUBLIC_KEY_LENGTH = 32;
        var KEY_SIZE = 0;

        byte[] plainAddr = new byte[0];
        // 00000000b..=00111111b (0..=63 inclusive): Simple account/address/network identifier.
        // The byte can be interpreted directly as such an identifier.
        if (ss58Prefix < 64)
        {
            KEY_SIZE = 1;
            plainAddr = new byte[35];
            plainAddr[0] = (byte)ss58Prefix;
            bytes.CopyTo(plainAddr.AsMemory(1));
        }
        else
        // 01000000b..=01111111b (64..=127 inclusive): Full address/address/network identifier.
        // The lower 6 bits of this byte should be treated as the upper 6 bits of a 14 bit identifier
        // value, with the lower 8 bits defined by the following byte. This works for all identifiers
        // up to 2**14 (16,383).
        if (ss58Prefix < 16384)
        {
            KEY_SIZE = 2;
            plainAddr = new byte[36];

            // parity style
            var ident = (short)ss58Prefix & 0b00111111_11111111; // clear first two bits
            var first = (byte)(((ident & 0b0000_0000_1111_1100) >> 2) | 0b0100_0000);
            var second = (byte)((ident >> 8) | (ident & 0b0000_0000_0000_0011) << 6);

            plainAddr[0] = first;
            plainAddr[1] = second;

            bytes.CopyTo(plainAddr.AsMemory(2));
        }
        else
        {
            throw new Exception("Unsupported prefix used, support only up to 16383!");
        }

        var ssPrefixed = new byte[SR25519_PUBLIC_SIZE + 7 + KEY_SIZE];
        var ssPrefixed1 = new byte[] { 0x53, 0x53, 0x35, 0x38, 0x50, 0x52, 0x45 };
        ssPrefixed1.CopyTo(ssPrefixed, 0);
        plainAddr.AsSpan(0, SR25519_PUBLIC_SIZE + KEY_SIZE).CopyTo(ssPrefixed.AsSpan(7));

        byte[] forHash = new byte[SR25519_PUBLIC_SIZE + 7 + KEY_SIZE];
        Array.Copy(ssPrefixed, 0, forHash, 0, SR25519_PUBLIC_SIZE + 7 + KEY_SIZE);
        //var blake2bHashed = Hasher.Blake2(ssPrefixed, 0, SR25519_PUBLIC_SIZE + 7 + KEY_SIZE);
        var blake2bHashed = Hasher.BlakeTwo(forHash, 64);
        plainAddr[0 + KEY_SIZE + PUBLIC_KEY_LENGTH] = blake2bHashed[0];
        plainAddr[1 + KEY_SIZE + PUBLIC_KEY_LENGTH] = blake2bHashed[1];

        var addrCh = Base58.Bitcoin.Encode(plainAddr).ToArray();

        return new string(addrCh);
    }

    public static byte[] GetPublicKeyFrom(string address)
    {
        return GetPublicKeyFrom(address, out _);
    }

    public static byte[] GetPublicKeyFrom(string address, out short network)
    {
        network = 42;
        var PUBLIC_KEY_LENGTH = 32;
        var PREFIX_SIZE = 0;
        var pubkByteList = new List<byte>();

        var bs58decoded = Base58.Bitcoin.Decode(address).ToArray();
        var len = bs58decoded.Length;

        byte[] ssPrefixed = { 0x53, 0x53, 0x35, 0x38, 0x50, 0x52, 0x45 };

        // 00000000b..=00111111b (0..=63 inclusive): Simple account/address/network identifier.
        if (len == 35)
        {
            PREFIX_SIZE = 1;
            // set network
            network = bs58decoded[0];
        }
        else
        // 01000000b..=01111111b (64..=127 inclusive)
        if (len == 36)
        {
            PREFIX_SIZE = 2;
            // set network
            byte b2up = (byte)((bs58decoded[0] << 2) & 0b1111_1100);
            byte b2lo = (byte)((bs58decoded[1] >> 6) & 0b0000_0011);
            byte b2 = (byte)(b2up | b2lo);
            byte b1 = (byte)(bs58decoded[1] & 0b0011_1111);
            network = (short)BitConverter.ToInt16(
                new byte[] { b2, b1 }, 0); // big endian, for BitConverter
        }

        else
        {
            throw new ApplicationException("Unsupported address size.");
        }

        pubkByteList.AddRange(ssPrefixed);
        pubkByteList.AddRange(bs58decoded.Take(PUBLIC_KEY_LENGTH + PREFIX_SIZE));

        var blake2bHashed = Hasher.BlakeTwo(pubkByteList.ToArray(), 64);
        if (bs58decoded[PUBLIC_KEY_LENGTH + PREFIX_SIZE] != blake2bHashed[0] ||
            bs58decoded[PUBLIC_KEY_LENGTH + PREFIX_SIZE + 1] != blake2bHashed[1])
        {
            throw new ApplicationException("Address checksum is wrong.");
        }

        return bs58decoded.Skip(PREFIX_SIZE).Take(PUBLIC_KEY_LENGTH).ToArray();

    }

}

