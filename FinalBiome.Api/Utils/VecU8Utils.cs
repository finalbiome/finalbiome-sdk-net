using FinalBiome.Api.Types;
using FinalBiome.Api.Types.Primitive;

namespace FinalBiome.Api.Utils;

public static class VecU8Utils
{
    /// <summary>
    /// Convert U8 vector to the string
    /// </summary>
    /// <param name="vec"></param>
    /// <returns></returns>
    public static string ToString(VecU8 vec)
    {
        return ToString(vec.Value);
    }

    /// <summary>
    /// Convert U8 vector to the string
    /// </summary>
    /// <param name="vec"></param>
    /// <returns></returns>
    public static string ToString(BoundedVecU8 vec)
    {
        return ToString(vec.Value);
    }

    /// <summary>
    /// Convert U8 array to the string
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static string ToString(U8[] arr)
    {
        byte[] bytes = arr.Select(v => v.Value).ToArray();
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
}
