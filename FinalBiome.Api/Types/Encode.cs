
namespace FinalBiome.Api.Types;

/// <summary>
/// The Encode interface is used for encoding of data into the SCALE format.
/// </summary>
public interface Encode
{
    /// <summary>
    /// Encodes the value
    /// </summary>
    /// <returns></returns>
    byte[] Encode();

    /// <summary>
    /// Encodes the value and appends it to a destination buffer.
    /// </summary>
    /// <param name="bytes"></param>
    void EncodeTo(ref List<byte> bytes)
    {
        bytes.AddRange(this.Encode());
    }
}

