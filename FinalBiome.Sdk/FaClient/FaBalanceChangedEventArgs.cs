namespace FinalBiome.Sdk;

using FaAssetId = UInt32;
using FaAssetBalance = UInt128;

/// <summary>
/// Event args of changing balance of some fungible asset
/// </summary>
public class FaBalanceChangedEventArgs : EventArgs
{
    /// <summary>
    /// FA id
    /// </summary>
    /// <value></value>
    public FaAssetId Id { get; internal set; }
    /// <summary>
    /// Fa balance
    /// </summary>
    /// <value></value>
    public FaAssetBalance Balance { get; internal set; }

    public FaBalanceChangedEventArgs(FaAssetId id, FaAssetBalance balance)
    {
        Id = id;
        Balance = balance;
    }
}
