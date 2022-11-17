using FinalBiome.Api.Utils;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FinalBiome.Api;

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

