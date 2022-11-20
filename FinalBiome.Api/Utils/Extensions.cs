using FinalBiome.Api.Utils;
using Newtonsoft.Json.Linq;
using System.Numerics;
using System.Text;

namespace FinalBiome.Api.Extensions;

public static class Extensions
{
    /// <summary>
    /// Converts a string slice to a byte slice.
    /// To convert the byte slice back into a string slice, use the <seealso cref="FromUtf8"/> function.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static byte[] AsBytes(this string str)
    {
        return Encoding.UTF8.GetBytes(str);
    }

    /// <summary>
    /// Converts a array of bytes to a string.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string FromUtf8(this byte[] bytes)
    {
        return Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    /// <inheritdoc cref="Convert.ToHexString"/>
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string ToHex(this IEnumerable<byte> bytes)
    {
        return $"0x{Convert.ToHexString(bytes.ToArray())}";
    }
}

/// <summary>
/// The Encode extension is used for encoding of data into the SCALE format.
/// <see cref="https://github.com/paritytech/parity-scale-codec#encode"/>
/// </summary>
public static class EncodeExtensions
{
    /// <summary>
    /// Convert self to a slice and append it to the destination.
    /// </summary>
    /// <param name="that"></param>
    /// <param name="bytes"></param>
    public static void EncodeTo(this IEnumerable<byte> that, ref List<byte> bytes)
    {
        bytes.AddRange(that);
    }

    /// <summary>
    /// Encodes the value
    /// </summary>
    /// <param name="that"></param>
    public static byte[] Encode(this byte that)
    {
        return new byte[] { that };
    }

    /// <summary>
    /// Encodes the value and appends it to a destination buffer.
    /// </summary>
    /// <param name="that"></param>
    /// <param name="bytes"></param>
    public static void EncodeTo(this byte that, ref List<byte> bytes)
    {
        bytes.Add(that);
    }

    /// <summary>
    /// Encodes the value
    /// </summary>
    /// <param name="that"></param>
    public static byte[] Encode(this uint that)
    {
        return BitConverter.GetBytes(that);
    }

    /// <summary>
    /// Encodes the value and appends it to a destination buffer.
    /// </summary>
    /// <param name="that"></param>
    /// <param name="bytes"></param>
    public static void EncodeTo(this uint that, ref List<byte> bytes)
    {
        bytes.AddRange(that.Encode());
    }

    /// <summary>
    /// Encodes the value
    /// </summary>
    /// <param name="that"></param>
    public static byte[] Encode(this ulong that)
    {
        return BitConverter.GetBytes(that);
    }
    /// <summary>
    /// Encodes the value and appends it to a destination buffer.
    /// </summary>
    /// <param name="that"></param>
    /// <param name="bytes"></param>
    public static void EncodeTo(this ulong that, ref List<byte> bytes)
    {
        bytes.AddRange(that.Encode());
    }
    /// <summary>
    /// Encodes the value
    /// </summary>
    /// <param name="that"></param>
    public static byte[] Encode(this UInt128 that)
    {
        return ((BigInteger)that).ToByteArray();
    }
    /// <summary>
    /// Encodes the value and appends it to a destination buffer.
    /// </summary>
    /// <param name="that"></param>
    /// <param name="bytes"></param>
    public static void EncodeTo(this UInt128 that, ref List<byte> bytes)
    {
        bytes.AddRange(that.Encode());
    }
}