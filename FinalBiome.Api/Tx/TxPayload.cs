using FinalBiome.Api.Extensions;

namespace FinalBiome.Api.Tx;

/// <summary>
/// This represents a transaction payload that can be submitted
/// to a node.
/// </summary>
public interface TxPayload
{
    /// <summary>
    /// Encode call data to the provided output.
    /// </summary>
    /// <param name="bytes"></param>
    void EncodeCallDataTo(ref List<byte> bytes);

    /// <summary>
    /// Encode call data and return the output. This is a convenience
    /// wrapper around [`TxPayload::EncodeCallDataTo`].
    /// </summary>
    /// <param name="bytes"></param>
    List<byte> EncodeCallData()
    {
        var v = new List<byte>();
        EncodeCallDataTo(ref v);
        return v;
    }
}

/// <summary>
/// This represents a statically generated transaction payload.
/// </summary>
public class StaticTxPayload : TxPayload
{
    byte palletIndex;
    byte callIndex;
    List<byte> callData;

    public StaticTxPayload(byte palletIndex, byte callIndex, List<byte> callData)
    {
        this.palletIndex = palletIndex;
        this.callIndex = callIndex;
        this.callData = callData;
    }

    public List<byte> CallData => callData;

    public void EncodeCallDataTo(ref List<byte> bytes)
    {
        palletIndex.EncodeTo(ref bytes);
        callIndex.EncodeTo(ref bytes);
        callData.EncodeTo(ref bytes);
    }
}

